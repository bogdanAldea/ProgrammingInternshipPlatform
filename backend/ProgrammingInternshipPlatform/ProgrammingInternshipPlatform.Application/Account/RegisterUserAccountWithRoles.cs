using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Storage;
using ProgrammingInternshipPlatform.Application.ResultPattern;
using ProgrammingInternshipPlatform.Dal.Context;
using ProgrammingInternshipPlatform.Domain.Account.UserAccounts;
using ProgrammingInternshipPlatform.Domain.Organisation.Company;
using ProgrammingInternshipPlatform.Domain.Shared.ErrorHandling.Exceptions;

namespace ProgrammingInternshipPlatform.Application.Account;

public record RegisterUserAccountWithRolesCommand(string FirstName, string LastName, string Email, string Password,
    string? PictureUrl, CompanyId CompanyId, IReadOnlyList<string> Roles) : IRequest<HandlerResult<UserAccount>>;
    
public class RegisterUserAccountWithRolesHandler : IRequestHandler<RegisterUserAccountWithRolesCommand, HandlerResult<UserAccount>>
{
    private readonly ProgrammingInternshipPlatformDbContext _context;
    private readonly UserManager<IdentityUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    
    public RegisterUserAccountWithRolesHandler(ProgrammingInternshipPlatformDbContext context,
        UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        _context = context;
        _userManager = userManager;
        _roleManager = roleManager;
    }
    
    public async Task<HandlerResult<UserAccount>> Handle(RegisterUserAccountWithRolesCommand request, CancellationToken cancellationToken)
    {
        var userAlreadyExistsWithRequestedEmail = await this.UserAlreadyExistsWithRequestedEmail(request.Email);
        if (userAlreadyExistsWithRequestedEmail) return HandleIdentityAlreadyExistsError();

        await using var transaction = await _context.Database.BeginTransactionAsync(cancellationToken);
        try
        {
            var newIdentityUser = new IdentityUser { Email = request.Email, UserName = request.Email };
            var createIdentityResult = await _userManager.CreateAsync(newIdentityUser, request.Password);
            if (!createIdentityResult.Succeeded)
            {
                await transaction.RollbackAsync(cancellationToken);
                return await HandleCreateIdentityError(createIdentityResult, transaction, cancellationToken);
            }

            var allRolesAllValid = await RequestedRolesAreValid(request.Roles);
            if (!allRolesAllValid)
            {
                var invalidRequestedRoleError = ApplicationError
                    .IdentityRegistrationFailure(ApplicationErrorMessages.UserAccount.InvalidRequestedRoles);
                return HandlerResult<UserAccount>.Fail(invalidRequestedRoleError);
            }
            await _userManager.AddToRolesAsync(newIdentityUser, request.Roles);
            
            try
            {
                var newUserAccount = await UserAccount.CreateNew(firstName: request.FirstName,
                    lastName: request.LastName,
                    pictureUrl: request.PictureUrl, companyId: request.CompanyId,
                    identityId: Guid.Parse(newIdentityUser.Id), cancellationToken: cancellationToken);
            
                var createdUserAccount = await _context.UserAccount.AddAsync(newUserAccount, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);
                await transaction.CommitAsync(cancellationToken);
                return HandlerResult<UserAccount>.Success(createdUserAccount.Entity);
            }
            catch (DomainModelValidationException exception)
            {
                await transaction.RollbackAsync(cancellationToken);
                var userAccountValidationError =
                    ApplicationError.DomainValidationFailure(exception.Message);
                return HandlerResult<UserAccount>.Fail(userAccountValidationError);
            }

        }
        catch (Exception e)
        {
            await transaction.RollbackAsync(cancellationToken);
            var transactionApplicationError = ApplicationError.IdentityRegistrationFailure(e.Message);
            return HandlerResult<UserAccount>.Fail(transactionApplicationError);
        }
    }

    private async Task<bool> UserAlreadyExistsWithRequestedEmail(string email)
    {
        var existingUserIdentity = await _userManager.FindByEmailAsync(email);
        return existingUserIdentity is not null;
    }
    
    private HandlerResult<UserAccount> HandleIdentityAlreadyExistsError()
    {
        var identityAlreadyRegisteredError = ApplicationError.IdentityUserAlreadyExists(
            ApplicationErrorMessages.UserAccount.EmailAlreadyRegistered);
        return HandlerResult<UserAccount>.Fail(identityAlreadyRegisteredError);
    }
    
    private async Task<HandlerResult<UserAccount>> HandleCreateIdentityError(IdentityResult identityResult,
        IDbContextTransaction transaction, CancellationToken cancellationToken)
    {
        var identityErrorMessages = new List<string>();
        identityResult.Errors.ToList().ForEach(error
            => identityErrorMessages.Add(error.Description));
        var identityRegistrationError = ApplicationError.AddErrors(
            ApplicationErrorType.IdentityRegistrationFailure, identityErrorMessages);
        await transaction.RollbackAsync(cancellationToken);
        return HandlerResult<UserAccount>.Fail(identityRegistrationError);
    }

    private async Task<bool> RequestedRolesAreValid(IEnumerable<string> requestedRoles)
    {
        var allRequestedRolesAreValid = false;
        foreach (var requestedRole in requestedRoles)
        {
            var validatedRole = await _roleManager.FindByNameAsync(requestedRole);
            if (validatedRole is null)
            {
                return false;
            }
            allRequestedRolesAreValid = true;
        }
        return allRequestedRolesAreValid;
    }
}
    