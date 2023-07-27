using Microsoft.AspNetCore.Identity;

namespace ProgrammingInternshipPlatform.Api.Accounts.Contracts.Responses;

public class AdministratorRoleResponse
{
    private AdministratorRoleResponse(IdentityRole role)
    {
        Name = role.Name!;
        Id = role.Id;
    }
    
    public string Name { get; }
    public string Id { get; }

    public static AdministratorRoleResponse MapFromIdentityRole(IdentityRole role)
    {
        return new AdministratorRoleResponse(role);
    }
}
