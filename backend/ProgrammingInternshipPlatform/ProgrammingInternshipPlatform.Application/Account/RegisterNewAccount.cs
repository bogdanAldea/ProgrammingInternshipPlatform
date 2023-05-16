using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Storage;
using ProgrammingInternshipPlatform.Application.ResultPattern;
using ProgrammingInternshipPlatform.Dal.Context;
using ProgrammingInternshipPlatform.Domain.Account.UserAccount;
using ProgrammingInternshipPlatform.Domain.Organization.Company;
using ProgrammingInternshipPlatform.Domain.Shared.Exceptions;

namespace ProgrammingInternshipPlatform.Application.Account;

public record RegisterNewAccountCommand(string FirstName, string LastName, string Email, string Password,
        string? PictureUrl, CompanyId CompanyId)
    : IRequest<HandlerResult<UserAccount>>;

public class RegisterNewAccountHandler : IRequestHandler<RegisterNewAccountCommand, HandlerResult<UserAccount>>
{
    private readonly ProgrammingInternshipPlatformDbContext _context;
    private readonly UserManager<IdentityUser> _userManager;

    public RegisterNewAccountHandler(ProgrammingInternshipPlatformDbContext context,
        UserManager<IdentityUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    public async Task<HandlerResult<UserAccount>> Handle(RegisterNewAccountCommand request,
        CancellationToken cancellationToken)
    {
        var existingUserIdentity = await FindIdentityByEmail(request.Email);

        if (existingUserIdentity is not null)
        {
            return HandleIdentityAlreadyRegisteredError();
        }

        await using var transaction = await _context.Database.BeginTransactionAsync(cancellationToken);

        try
        {
            var newUserIdentity = new IdentityUser { Email = request.Email, UserName = request.Email };
            var createdUserIdentity = await _userManager.CreateAsync(newUserIdentity, request.Password);

            if (createdUserIdentity.Succeeded)
            {
                try
                {
                    return await HandleCreateUserAccount(request, newUserIdentity.Id, transaction, cancellationToken);
                
                }
                catch (DomainModelValidationException exception)
                {
                    await transaction.RollbackAsync(cancellationToken);
                    return HandleUserAccountValidationError(exception.Message);
                }
            }
            return HandleIdentityRegistrationError(createdUserIdentity.Errors);
            
        }
        catch (Exception exception)
        {
            await transaction.RollbackAsync(cancellationToken);
            return HandleTransactionError(exception.Message);
        }

    }

    private async Task<IdentityUser> FindIdentityByEmail(string emailAddress)
    {
        return await _userManager.FindByEmailAsync(emailAddress);
    }

    private HandlerResult<UserAccount> HandleIdentityAlreadyRegisteredError()
    {
        var existingUserIdentityApplicationError =
            ApplicationError.IdentityUserAlreadyExists(ApplicationErrorMessages.UserAccount
                .EmailAlreadyRegistered);
        return HandlerResult<UserAccount>.Fail(existingUserIdentityApplicationError);
    }

    private async Task<HandlerResult<UserAccount>> HandleCreateUserAccount(RegisterNewAccountCommand request, string identityId, IDbContextTransaction transaction, CancellationToken cancellationToken)
    {
        var newUserAccount = await UserAccount.CreateNew(firstName: request.FirstName, lastName: request.LastName,
            pictureUrl: request.PictureUrl, companyId: request.CompanyId,
            identityId: Guid.Parse(identityId), cancellationToken: cancellationToken);

        var createdUserAccount = await _context.UserAccount.AddAsync(newUserAccount, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        await transaction.CommitAsync(cancellationToken);
        return HandlerResult<UserAccount>.Success(createdUserAccount.Entity);
    }

    private HandlerResult<UserAccount> HandleUserAccountValidationError(string errorMessage)
    {
        var domainValidationError = ApplicationError.DomainValidationFailure(errorMessage);
        return HandlerResult<UserAccount>.Fail(domainValidationError);
    }

    private HandlerResult<UserAccount> HandleIdentityRegistrationError(IEnumerable<IdentityError> identityErrors)
    {
        List<string> identityRegistrationErrors = new();
        identityErrors.ToList()
            .ForEach(error => identityRegistrationErrors.Add(error.Description));
        var errors =  ApplicationError.AddErrors(ApplicationErrorType.IdentityRegistrationFailure, identityRegistrationErrors);
        return HandlerResult<UserAccount>.Fail(errors);
    }

    private HandlerResult<UserAccount> HandleTransactionError(string errorMessage)
    {
        var unknownApplicationError = ApplicationError.IdentityRegistrationFailure(errorMessage);
        return HandlerResult<UserAccount>.Fail(unknownApplicationError);
    }
}