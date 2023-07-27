using ProgrammingInternshipPlatform.Domain.Backlog.Cards;
using ProgrammingInternshipPlatform.Domain.Backlog.Stages;

namespace ProgrammingInternshipPlatform.Api.API.Constants;

public static class ApiRoutes
{
    public const string IdRoute = "{id}";
    
    public static class UserAccountRoutes
    {
        public const string AccountRegistration = "signup";
        public const string AccountAuthentication = "signin";
        public const string AccountRolesAdd = $"{IdRoute}/roles/add";
        public const string AccountRolesRemove = $"{IdRoute}/roles/remove";
        
        public static class Roles
        {
            public const string Administrator = "administrator";
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

}