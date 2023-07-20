using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using ProgrammingInternshipPlatform.Application.ResultPattern;
using ProgrammingInternshipPlatform.Dal.Context;
using ProgrammingInternshipPlatform.Domain.Account.UserAccounts;
using ProgrammingInternshipPlatform.Domain.Shared.ErrorHandling.Exceptions;

namespace ProgrammingInternshipPlatform.Application.Account.UserAccountAuthentication;

public record RegisterAdministratorAccountWithRolesCommand(string FirstName, string LastName, string Email, string Password,
    string? PictureUrl, IReadOnlyList<string> Roles) : IRequest<HandlerResult<UserAccount>>;

public class
    RegisterAdministratorAccountWithRolesHandler : IRequestHandler<RegisterAdministratorAccountWithRolesCommand,
        HandlerResult<UserAccount>>
{
    private readonly ProgrammingInternshipPlatformDbContext _context;
    private readonly UserManager<IdentityUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public RegisterAdministratorAccountWithRolesHandler(ProgrammingInternshipPlatformDbContext context,
        UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        _context = context;
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public async Task<HandlerResult<UserAccount>> Handle(RegisterAdministratorAccountWithRolesCommand request,
        CancellationToken cancellationToken)
    {
        var identityAlreadyExists = await CheckIfEmailIsAlreadyRegistered(request.Email, cancellationToken);

        if (identityAlreadyExists)
        {
            return HandlerResultFailureHelper.IdentityAlreadyRegisteredFailure<UserAccount>(
                ApplicationErrorMessages.UserAccount.EmailAlreadyRegistered);
        }

        List<IdentityRole> validatedRoles = new();
        foreach (var roleId in request.Roles)
        {
            var role = await _roleManager.FindByIdAsync(roleId);
            if (role is null)
            {
                return HandlerResultFailureHelper.NotFoundFailure<UserAccount>(
                    ApplicationErrorMessages.UserAccount.RoleNotFound);
            }

            validatedRoles.Add(role);
        }
        
        await using var transaction = await _context.Database.BeginTransactionAsync(cancellationToken);
        try
        {
            var newIdentity = new IdentityUser { Email = request.Email, UserName = request.Email};
            var createdIdentity = await _userManager.CreateAsync(newIdentity, request.Password);
            if (!createdIdentity.Succeeded)
            {
                return await HandleIdentityCreationError(createdIdentity, transaction, cancellationToken);
            }

            var roleAssignResult = await AddRolesToIdentity(newIdentity, validatedRoles);
            if (!roleAssignResult.Succeeded)
            {
                return await HandleIdentityCreationError(createdIdentity, transaction, cancellationToken);
            }

            try
            {
                return await CreateUserAccountForIdentity(request, newIdentity, cancellationToken, transaction);
            }
            catch (DomainModelValidationException exception)
            {
                return await HandleUserAccountCreationError(transaction, exception.Message, cancellationToken);
            }
        }
        catch (Exception exception)
        {
            return await HandleTransactionError(transaction, exception.Message, cancellationToken);
        }
    }

    private async Task<bool> CheckIfEmailIsAlreadyRegistered(string email, CancellationToken cancellationToken)
    {
        return await _userManager.Users.AnyAsync(user => user.Email == email, cancellationToken);
    }

    private async Task<IdentityResult> AddRolesToIdentity(IdentityUser newIdentity,
        IReadOnlyList<IdentityRole> validatedRoles)
    {
        var roleNames = validatedRoles.Select(role => role.Name);
        return await _userManager.AddToRolesAsync(newIdentity, roleNames);
    }

    private async Task<HandlerResult<UserAccount>> HandleIdentityCreationError(IdentityResult identityResult,
        IDbContextTransaction transaction, CancellationToken cancellationToken)
    {
        var identityErrorMessages = new List<string>();
        identityResult.Errors.ToList().ForEach(error
            => identityErrorMessages.Add(error.Description));

        await transaction.RollbackAsync(cancellationToken);

        return HandlerResultFailureHelper.IdentityRegistrationFailure<UserAccount>(identityErrorMessages);
    }

    private async Task<HandlerResult<UserAccount>> CreateUserAccountForIdentity(
        RegisterAdministratorAccountWithRolesCommand request,
        IdentityUser newIdentity, CancellationToken cancellationToken, IDbContextTransaction transaction)
    {
        // This should be a factory pattern
        var newUserAccount = await UserAccount.CreateNew(
                firstName: request.FirstName,
                lastName: request.LastName,
                pictureUrl: request.PictureUrl,
                identityId: Guid.Parse(newIdentity.Id),
                cancellationToken
            );

        var createdUserAccount = await _context.UserAccount.AddAsync(newUserAccount, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        await transaction.CommitAsync(cancellationToken);
        return HandlerResult<UserAccount>.Success(createdUserAccount.Entity);
    }

    private async Task<HandlerResult<UserAccount>> HandleUserAccountCreationError(IDbContextTransaction transaction,
        string errorMessage, CancellationToken cancellationToken)
    {
        await transaction.RollbackAsync(cancellationToken);
        return HandlerResultFailureHelper.DomainValidationFailure<UserAccount>(errorMessage);
    }

    private async Task<HandlerResult<UserAccount>> HandleTransactionError(IDbContextTransaction transaction,
        string errorMessage, CancellationToken cancellationToken)
    {
        await transaction.RollbackAsync(cancellationToken);
        return HandlerResultFailureHelper.TransactionFailure<UserAccount>(errorMessage);
    }
}