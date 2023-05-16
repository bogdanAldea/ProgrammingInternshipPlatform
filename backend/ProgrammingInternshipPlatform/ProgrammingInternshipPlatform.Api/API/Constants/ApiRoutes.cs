namespace ProgrammingInternshipPlatform.Api.API.Constants;

public static class ApiRoutes
{
    public const string IdRoute = "{id}";
    
    public static class UserAccountRoutes
    {
    }
    
    public static class InternshipRoutes
    {
        public const string StartDateRescheduling = $"{IdRoute}/timeframe/start-date";
        public const string EndDateExtending = $"{IdRoute}/timeframe/end-date";
    }
}