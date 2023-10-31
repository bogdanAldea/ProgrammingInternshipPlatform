namespace ProgrammingInternshipPlatform.Api.API.Constants;

public static class ApiRoutes
{
    public const string BaseIdRoute = "{id}";
    
    public static class GeneralCurriculum
    {
        public const string TopicVersions = $"{BaseIdRoute}/versions";
        public const string TopicReadyToVersion = $"{BaseIdRoute}/ready-to-version";
    }
    
}