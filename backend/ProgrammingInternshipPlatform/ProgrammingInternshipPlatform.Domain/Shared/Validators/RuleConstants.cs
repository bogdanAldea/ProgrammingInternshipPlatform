using System.Globalization;

namespace ProgrammingInternshipPlatform.Domain.Shared.Validators;

public static class RuleConstants
{
    public const int PositiveValue = 0;
    public static class InternshipConstants
    {
        public const int MinDurationInMonths = 1;
        public const int MinInternsToEnrol = 1;
    }
    
    public static class GeneralCurriculum
    {
        public const int TopicTitleMaxLength = 50;
        public const int TopicDescriptionMaxLength = 255;
        
        public const int LessonTitleMaxLength = 50;
        public const int LessonDescriptionMaxLength = 255;
        
        public const int AssignmentTitleMaxLength = 50;
        public const int AssignmentDescriptionMaxLength = 255;
    }
}