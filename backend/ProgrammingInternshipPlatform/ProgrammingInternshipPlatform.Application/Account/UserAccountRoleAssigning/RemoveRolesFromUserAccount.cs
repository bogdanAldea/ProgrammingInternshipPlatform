using MediatR;
using Microsoft.AspNetCore.Identity;
using ProgrammingInternshipPlatform.Application.ResultPattern;
using ProgrammingInternshipPlatform.Domain.Account.UserAccounts;

namespace ProgrammingInternshipPlatform.Application.Account.UserAccountRoleAssigning;

public record RemoveRolesFromUserAccountCommand(Guid IdentityId, IEnumerable<string> Roles)
    : IRequest<HandlerResult<UserAccount>>;

public class RemoveRolesFromUserAccountHandler 
    : IRequestHandler<RemoveRolesFromUserAccountCommand, HandlerResult<UserAccount>>
{
    private readonly UserManager<IdentityUser> _context;

    public RemoveRolesFromUserAccountHandler(UserManager<IdentityUser> context)
    {
        _context = context;
    }
    
    public async Task<HandlerResult<UserAccount>> Handle(RemoveRolesFromUserAccountCommand request, CancellationToken cancellationToken)
    {
        var accountIdentity = await _context.FindByIdAsync(request.IdentityId.ToString());
        if (accountIdentity is null)
        {
            var identityNotFoundError =
                ApplicationError.NotFoundFailure(ApplicationErrorMessages.UserAccount.AccountIdentityNotFound);
            return HandlerResult<UserAccount>.Fail(identityNotFoundError);
        }

        await _context.RemoveFromRolesAsync(accountIdentity, request.Roles);
        return HandlerResult<UserAccount>.Success();
    }
}