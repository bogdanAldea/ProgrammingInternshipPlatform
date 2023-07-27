using System.Security.Claims;

namespace ProgrammingInternshipPlatform.Api.API.Extensions;

public static class ClaimsPrincipalExtensions
{
    public static Guid GetOrganisationGuid(this ClaimsPrincipal user)
    {
        var organisationId = user.Claims
            .Where(claim => claim.Type == "organisationId")
            .Select(claim => claim.Value)
            .SingleOrDefault();
        return Guid.Parse(organisationId!);
    }
}