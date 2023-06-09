using ProgrammingInternshipPlatform.Domain.Backlog.Cards;
using ProgrammingInternshipPlatform.Domain.Backlog.Stages;

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
        public const string InternshipInternsEnrollment = $"{IdRoute}/interns";
    }

    public static class BoardRoutes
    {
        public const string StageIdRoute = "{stageId}";
        public const string BoardStages = $"{IdRoute}/stages";
        public const string StageCards = $"{IdRoute}/stages/{StageIdRoute}";
    }
}