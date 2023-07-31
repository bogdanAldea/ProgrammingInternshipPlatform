namespace ProgrammingInternshipPlatform.Domain.Shared.Validators;

public static class RuleFailureMessages
{
    public static class InternshipMessages
    {
        public const string EmptyOrNullProperty = "{PropertyName} is required and must be valid.";
        public const string InvalidMinDurationInMonths = "{PropertyName} is lower than expected";
        public const string InvalidMinInternsToEnrol = "{PropertyName} is lower than expected";
        public const string StatusNotAnEnumValue = "{PropertyName not in enum}";
        public const string InvalidStatusTransition = "{PropertyName} transition is not valid.";
        public const string InvalidStatusAtCreation = "{PropertyName} must be set to Setup In Progress at Creation.";
    }
    
    public static class TimeframeMessages
    {
        public const string EmptyOrNullProperty = "{PropertyName} is required and must be valid.";
        public const string StartDateSetInThePast = "{PropertyName} cannot be set in the past.";
        public const string EndDateEqualOrLowerThanStartDate =
            "{PropertyName} cannot be more recent than the start date of the internship.";
    }
    
    public static class UserAccountMessages
    {
        public const string EmptyOrNullProperty = "{PropertyName} is required and must be valid.";
        public const string JoiningDateSetInThePast = "{PropertyName} must start from today.";
    }
    
    public static class BoardMessages
    {
        public const string EmptyOrNullProperty = "{PropertyName} is required and must be valid.";
    }
    
    public static class CardMessages 
    {
        public const string EmptyOrNullProperty = "{PropertyName} is required and must be valid.";
        public const string StatusNotAnEnumValue = "{PropertyName not in enum}";
    }
    
    public static class StageMessages 
    {
        public const string EmptyOrNullProperty = "{PropertyName} is required and must be valid.";
    }
    
    public static class ProjectMessages
    {
        public const string EmptyOrNullProperty = "{PropertyName} is required and must be valid.";
        public const string StatusNotAnEnumValue = "{PropertyName not in enum}";
        public const string StartDateNotSet = "{PropertyName} must be set when project is started.";
        public const string CompletedDateNotSet = "{PropertyName} must be set when project is completed.";
    }
}