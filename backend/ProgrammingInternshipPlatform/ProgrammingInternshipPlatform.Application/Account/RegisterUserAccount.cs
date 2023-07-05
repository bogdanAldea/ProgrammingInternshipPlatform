using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Storage;
using ProgrammingInternshipPlatform.Application.ResultPattern;
using ProgrammingInternshipPlatform.Dal.Context;
using ProgrammingInternshipPlatform.Domain.Account.UserAccounts;
using ProgrammingInternshipPlatform.Domain.Organisation.Companies;
using ProgrammingInternshipPlatform.Domain.Shared.ErrorHandling.Exceptions;

namespace ProgrammingInternshipPlatform.Application.Account;

public record RegisterUserAccountCommand(string FirstName, string LastName, string Email, string Password,
    string? PictureUrl) : IRequest<HandlerResult<UserAccount>>;

public class RegisterUserAccountHandler : IRequestHandler<RegisterUserAccountCommand, HandlerResult<UserAccount>>
{
    private readonly ProgrammingInternshipPlatformDbContext _context;
    private readonly UserManager<IdentityUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public RegisterUserAccountHandler(ProgrammingInternshipPlatformDbContext context,
        UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        _context = context;
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public async Task<HandlerResult<UserAccount>> Handle(RegisterUserAccountCommand request,
        CancellationToken cancellationToken)
    {
        var existingUserIdentity = await FindIdentityUserByEmail(request.Email);
        if (existingUserIdentity is not null)
        {
            return HandleIdentityAlreadyExistsError();
        }

        await using var transaction = await _context.Database.BeginTransactionAsync(cancellationToken);
        try
        {
            var newIdentityUser = CreateIdentityUser(request.Email);
            var createdIdentityUser = await SaveCreatedIdentityUser(newIdentityUser, request.Password);
            if (!createdIdentityUser.Succeeded)
            {
                return await HandleCreateIdentityError(createdIdentityUser, transaction, cancellationToken);
            }

            try
            {
                return await HandleCreateUserAccount(request, newIdentityUser.Id, transaction, cancellationToken);
            }
            catch (DomainModelValidationException exception)
            {
                return await HandleDomainValidationError(exception.Message, transaction, cancellationToken);
            }
        }
        catch (Exception exception)
        {
            return await HandleTransactionError(exception.Message, transaction, cancellationToken);
        }
    }

    private async Task<IdentityUser?> FindIdentityUserByEmail(string emailAddress)
    {
        return await _userManager.FindByEmailAsync(emailAddress);
    }

    private HandlerResult<UserAccount> HandleIdentityAlreadyExistsError()
    {
        var identityAlreadyRegisteredError = ApplicationError.IdentityUserAlreadyExists(
            ApplicationErrorMessages.UserAccount.EmailAlreadyRegistered);
        return HandlerResult<UserAccount>.Fail(identityAlreadyRegisteredError);
    }

    private IdentityUser CreateIdentityUser(string emailAddress)
    {
        return new IdentityUser { Email = emailAddress, UserName = emailAddress };
    }

    private async Task<IdentityResult> SaveCreatedIdentityUser(IdentityUser identityUser, string password)
    {
        return await _userManager.CreateAsync(identityUser, password);
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

    private async Task<HandlerResult<UserAccount>> HandleCreateUserAccount(RegisterUserAccountCommand request,
        string identityUserId, IDbContextTransaction transaction, CancellationToken cancellationToken)
    {
        var newUserAccount = await UserAccount.CreateNew(firstName: request.FirstName,
            lastName: request.LastName,
            pictureUrl: request.PictureUrl,
            identityId: Guid.Parse(identityUserId), cancellationToken: cancellationToken);

        var createdUserAccount = await _context.UserAccount.AddAsync(newUserAccount, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        await transaction.CommitAsync(cancellationToken);
        return HandlerResult<UserAccount>.Success(createdUserAccount.Entity);
    }

    private async Task<HandlerResult<UserAccount>> HandleDomainValidationError(string errorMessage, IDbContextTransaction transaction, CancellationToken cancellationToken)
    {
        await transaction.RollbackAsync(cancellationToken);
        var userAccountValidationError =
            ApplicationError.DomainValidationFailure(errorMessage);
        return HandlerResult<UserAccount>.Fail(userAccountValidationError);
    }

    private async Task<HandlerResult<UserAccount>> HandleTransactionError(string errorMessage, IDbContextTransaction transaction, CancellationToken cancellationToken)
    {
        await transaction.RollbackAsync(cancellationToken);
        var transactionApplicationError = ApplicationError.IdentityRegistrationFailure(errorMessage);
        return HandlerResult<UserAccount>.Fail(transactionApplicationError);
    }
}