using MediatR;
using Microsoft.AspNetCore.Identity;
using ProgrammingInternshipPlatform.Application.ResultPattern;
using ProgrammingInternshipPlatform.Domain.Account.UserAccounts;

namespace ProgrammingInternshipPlatform.Application.Account.UserAccountRoleAssigning;

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
        var identityAccount = await FindUserAccountIdentity(request.IdentityId);
        if (identityAccount is null)
        {
            return ErrorValidationHelper.NotFoundFailure<UserAccount>(
                ApplicationErrorMessages.UserAccount.AccountIdentityNotFound);
        }

        await _context.AddToRolesAsync(identityAccount, request.Roles);
        return HandlerResult<UserAccount>.Success();
    }

    private async Task<IdentityUser> FindUserAccountIdentity(Guid identityId)
    {
        return await _context.FindByIdAsync(identityId.ToString());
    }

}