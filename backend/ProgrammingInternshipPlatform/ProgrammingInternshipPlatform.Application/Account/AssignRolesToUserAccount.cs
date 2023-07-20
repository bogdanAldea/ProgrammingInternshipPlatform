using MediatR;
using Microsoft.AspNetCore.Identity;
using ProgrammingInternshipPlatform.Application.ResultPattern;
using ProgrammingInternshipPlatform.Dal.Context;
using ProgrammingInternshipPlatform.Domain.Account.UserAccounts;

namespace ProgrammingInternshipPlatform.Application.Account;

public record AssignRolesToUserAccountCommand(Guid IdentityId, IEnumerable<string> Roles) 
    : IRequest<HandlerResult<UserAccount>>;
    
public class AssignRolesToUserAccountHandler 
    : IRequestHandler<AssignRolesToUserAccountCommand, HandlerResult<UserAccount>>
{
    private readonly UserManager<IdentityUser> _context;

    public AssignRolesToUserAccountHandler(UserManager<IdentityUser> context)
    {
        _context = context;
    }
    
    public async Task<HandlerResult<UserAccount>> Handle(AssignRolesToUserAccountCommand request, CancellationToken cancellationToken)
    {
        var identityAccount = await _context.FindByIdAsync(request.IdentityId.ToString());
        if (identityAccount is null)
        {
            var identityNotFoundError =
                ApplicationError.NotFoundFailure(ApplicationErrorMessages.UserAccount.AccountIdentityNotFound);
            return HandlerResult<UserAccount>.Fail(identityNotFoundError);
        }

        await _context.AddToRolesAsync(identityAccount, request.Roles);
        return HandlerResult<UserAccount>.Success();
    }
}