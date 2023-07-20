using ProgrammingInternshipPlatform.Domain.Backlog.Cards;
using ProgrammingInternshipPlatform.Domain.Backlog.Stages;

namespace ProgrammingInternshipPlatform.Api.API.Constants;

public static class ApiRoutes
{
    public const string IdRoute = "{id}";
    
    public static class UserAccountRoutes
    {
        public const string AccountRegistration = "registration";
        public const string AccountAuthentication = "login";
        public const string AccountRolesAdd = $"{IdRoute}/{Roles.BaseRoute}/add";
        public const string AccountRolesRemove = $"{IdRoute}/{Roles.BaseRoute}/remove";
        
        public static class Roles
        {
            public const string BaseRoute = "roles";
            public const string Administrator = $"{BaseRoute}/administrator";
        }
    }
    
    public static class InternshipRoutes
    {
        public const string StartDateRescheduling = $"{IdRoute}/timeframe/start-date";
        public const string EndDateExtending = $"{IdRoute}/timeframe/end-date";
        public const string InternshipInternsEnrollment = $"{IdRoute}/interns";
        public const string InternshipSettings = $"{IdRoute}/settings";
        public const string EnrolledInterns = $"{IdRoute}/interns";
    }
    
    public static class OrganisationRoutes
    {
        public const string AllInternships = $"{IdRoute}/internships";
        public const string AllUserAccounts = $"{IdRoute}/user-accounts";
    }
}