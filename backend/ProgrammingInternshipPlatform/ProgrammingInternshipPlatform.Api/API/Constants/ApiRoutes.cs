namespace ProgrammingInternshipPlatform.Api.API.Constants;

public static class ApiRoutes
{
    public const string IdRoute = "{id}";
    
    public static class InternshipRoutes
    {
        public const string Setup = $"{IdRoute}/setup";
        public const string Mentorships = $"{IdRoute}/mentorships";
        public const string MentorshipIdRoute = "{mentorshipId}";
        public const string MentorshipPair = $"{IdRoute}/mentorships/{MentorshipIdRoute}";
    }
    
    public static class ChapterRoutes
    {
        public const string Lessons = $"{IdRoute}/lessons";
        public const string Version = $"{IdRoute}/version";
    }
}