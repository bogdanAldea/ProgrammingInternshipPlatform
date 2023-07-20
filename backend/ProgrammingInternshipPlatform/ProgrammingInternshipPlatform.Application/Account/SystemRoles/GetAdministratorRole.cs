using MediatR;
using Microsoft.AspNetCore.Identity;
using ProgrammingInternshipPlatform.Application.ResultPattern;

namespace ProgrammingInternshipPlatform.Application.Account.SystemRoles;

public record GetAdministratorRoleQuery : IRequest<HandlerResult<IdentityRole>>;

public class GetAdministratorRoleHandler : IRequestHandler<GetAdministratorRoleQuery, HandlerResult<IdentityRole>>
{
    private readonly RoleManager<IdentityRole> _roleManager;

    public GetAdministratorRoleHandler(RoleManager<IdentityRole> roleManager)
    {
        _roleManager = roleManager;
    }
    
    public async Task<HandlerResult<IdentityRole>> Handle(GetAdministratorRoleQuery request, CancellationToken cancellationToken)
    {
        var adminRole = await _roleManager.FindByNameAsync("Administrator");
        return HandlerResult<IdentityRole>.Success(adminRole);
    }
}