using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using ProgrammingInternshipPlatform.Application.ResultPattern;
using ProgrammingInternshipPlatform.Dal.Context;
using ProgrammingInternshipPlatform.Domain.Account.UserAccounts;
using ProgrammingInternshipPlatform.Domain.Organisation.Companies;
using ProgrammingInternshipPlatform.Domain.Shared.ErrorHandling.Exceptions;

namespace ProgrammingInternshipPlatform.Application.Account.UserAccountAuthentication;

public record RegisterMemberUserWithRolesCommand(string FirstName, string LastName, string Email,
    Guid CompanyId, IReadOnlyList<string> Roles) : IRequest<HandlerResult<UserAccount>>;

public class RegisterMemberUserWithRolesHandler : IRequestHandler<RegisterMemberUserWithRolesCommand,
    HandlerResult<UserAccount>>
{
    private readonly ProgrammingInternshipPlatformDbContext _context;
    private readonly UserManager<IdentityUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public RegisterMemberUserWithRolesHandler(ProgrammingInternshipPlatformDbContext context,
        UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        _context = context;
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public async Task<HandlerResult<UserAccount>> Handle(RegisterMemberUserWithRolesCommand request,
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
                    ApplicationErrorMessages.UserAccount.UserAccountNotFound);
            }

            validatedRoles.Add(role);
        }

        await using var transaction = await _context.Database.BeginTransactionAsync(cancellationToken);
        try
        {
            var newIdentity = new IdentityUser { Email = request.Email, UserName = request.Email };
            var tempGeneratedPassword = GenerateTemporaryPassword();
            var createdIdentity = await _userManager.CreateAsync(newIdentity, tempGeneratedPassword);
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
        RegisterMemberUserWithRolesCommand request,
        IdentityUser newIdentity, CancellationToken cancellationToken, IDbContextTransaction transaction)
    {
        var newUserAccount = await UserAccount.CreateNew(
            firstName: request.FirstName,
            lastName: request.LastName,
            identityId: Guid.Parse(newIdentity.Id),
            companyId: new CompanyId((Guid)request.CompanyId),
            cancellationToken);


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

    private string GenerateTemporaryPassword()
    {
        Random random = new Random();
        List<char> requiredChars = new List<char>();

        // Generate at least one capital letter
        requiredChars.Add((char)random.Next('A', 'Z' + 1));

        // Generate at least one symbol
        string symbols = "!@#$%^&*";
        requiredChars.Add(symbols[random.Next(symbols.Length)]);

        // Generate at least one number
        requiredChars.Add((char)random.Next('0', '9' + 1));

        int requiredLength = 16;
        int remainingLength = requiredLength - requiredChars.Count;

        // Generate remaining characters
        string allChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#$%^&*";
        for (int i = 0; i < remainingLength; i++)
        {
            requiredChars.Add(allChars[random.Next(allChars.Length)]);
        }

        // Shuffle the characters randomly
        requiredChars = requiredChars.OrderBy(c => random.Next()).ToList();

        // Convert the list of characters to a string
        string result = new string(requiredChars.ToArray());
        return result;
    }
}