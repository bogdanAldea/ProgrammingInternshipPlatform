namespace ProgrammingInternshipPlatform.Dal.Configurations;

public static class AggregatesToTableNames
{
    private const string InternshipManagementAggregate = "InternshipManagement";
    private const string GeneralCurriculumManagementAggregate = "GeneralCurriculumManagement";
    
    public static class InternshipManagement
    {
        public const string Internships = $"{InternshipManagementAggregate}.Internships";
        public const string Trainers = $"{InternshipManagementAggregate}.Trainers";
        public const string Interns = $"{InternshipManagementAggregate}.Interns";
        public const string Mentorships = $"{InternshipManagementAggregate}.Mentorships";
        public const string AssignedTrainers = $"{InternshipManagementAggregate}.AssignedTrainers";
    }
    
    public static class CurriculumManagement
    {
        public const string Topics = $"{GeneralCurriculumManagementAggregate}.Topics";
        public const string Lessons = $"{GeneralCurriculumManagementAggregate}.Lessons";
        public const string Assignments = $"{GeneralCurriculumManagementAggregate}.Assignments";
        public const string LearningResources = $"{GeneralCurriculumManagementAggregate}.LearningResources";
    }
}