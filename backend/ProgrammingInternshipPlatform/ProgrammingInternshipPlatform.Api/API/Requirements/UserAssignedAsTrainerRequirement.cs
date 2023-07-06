using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using ProgrammingInternshipPlatform.Dal.Context;
using ProgrammingInternshipPlatform.Domain.Account.UserAccounts;
using ProgrammingInternshipPlatform.Domain.InternshipManagement.Internships;

namespace ProgrammingInternshipPlatform.Api.API.Requirements;

public record UserAssignedAsTrainerRequirement : IAuthorizationRequirement;

public class UserAssignedAsTrainerHandler : AuthorizationHandler<UserEnrolledAsInternRequirement>
{
    private readonly ProgrammingInternshipPlatformDbContext _dbContext;
    private readonly IMemoryCache _cache;

    public UserAssignedAsTrainerHandler(ProgrammingInternshipPlatformDbContext dbContext, IMemoryCache cache)
    {
        _dbContext = dbContext;
        _cache = cache;
    }
    
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, UserEnrolledAsInternRequirement requirement)
    {
        throw new NotImplementedException();
    }

    private bool HasUserTrainerRole(ClaimsPrincipal user)
    {
        return user.IsInRole("Trainer");
    }
    
    private Guid GetUserAccountIdFromClaims(ClaimsPrincipal user)
    {
        var accountIdAsString =  user.FindFirstValue("account_identifier");
        return Guid.Parse(accountIdAsString!);
    }
    
    private Guid GetRequestedInternshipId(object resource)
    {
        var httpContext = resource as HttpContext;
        var routeData = httpContext?.Request.RouteValues;
        var id = routeData?["id"]?.ToString();
        return Guid.Parse(id!);
    }
    
    private bool IsUserEnrolledInInternshipAsIntern(Guid userAccountId, Guid internshipId)
    {
        if (_cache.TryGetValue($"assignedInInternship_{userAccountId}_{internshipId}", out bool isUserAssigned))
        {
            return isUserAssigned;
        }
        
        var requestedInternship = _dbContext.Internships
            .Include(internship => internship.Trainers)
            .SingleOrDefault(internship => internship.Id == new InternshipId(internshipId));

        if (requestedInternship is not null)
        {
            isUserAssigned = requestedInternship.Interns.Any(intern =>
                intern.AccountId == new AccountId(userAccountId!));

            _cache.Set($"assignedInInternship_{userAccountId}_{internshipId}", isUserAssigned);
        }

        return isUserAssigned;
    }
}