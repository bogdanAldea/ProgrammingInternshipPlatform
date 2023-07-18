using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using ProgrammingInternshipPlatform.Dal.Context;
using ProgrammingInternshipPlatform.Domain.Account.UserAccounts;
using ProgrammingInternshipPlatform.Domain.InternshipManagement.Internships;

namespace ProgrammingInternshipPlatform.Api.API.Requirements;
public record UserEnrolledAsInternRequirement : IAuthorizationRequirement;
public class UserEnrolledAsInternHandler : AuthorizationHandler<UserEnrolledAsInternRequirement>
{
    private readonly ProgrammingInternshipPlatformDbContext _dbContext;
    private readonly IMemoryCache _cache;

    public UserEnrolledAsInternHandler(ProgrammingInternshipPlatformDbContext dbContext, IMemoryCache cache)
    {
        _dbContext = dbContext;
        _cache = cache;
    }

    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context,
        UserEnrolledAsInternRequirement requirement)
    {
        if (!HasUserInternRole(context))
        {
            return Task.CompletedTask;
        }

        var userAccountId = GetUserAccountIdFromClaims(context.User);
        var internshipId = GetRequestedInternshipId(context.Resource!);

        if (IsUserEnrolledInInternshipAsIntern(userAccountId, internshipId))
        {
            context.Succeed(requirement);
        }
        else
        {
            context.Fail();
        }

        return Task.CompletedTask;
    }

    private bool HasUserInternRole(AuthorizationHandlerContext context)
    {
        return context.User.IsInRole("Intern");
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
        if (_cache.TryGetValue($"enrolledInInternship_{userAccountId}_{internshipId}", out bool isUserEnrolled))
        {
            return isUserEnrolled;
        }
        
        var requestedInternship = _dbContext.Internships
            .Include(internship => internship.Interns)
            .SingleOrDefault(internship => internship.Id == new InternshipId(internshipId));

        if (requestedInternship is not null)
        {
            isUserEnrolled = requestedInternship.Interns.Any(intern =>
                intern.AccountId == new AccountId(userAccountId!));

            _cache.Set($"enrolledInInternship_{userAccountId}_{internshipId}", isUserEnrolled);
        }

        return isUserEnrolled;
    }
}