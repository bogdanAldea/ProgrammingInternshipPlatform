namespace ProgrammingInternshipPlatform.Domain.Shared.Validators;

public static class RuleFailureMessages
{
    public static class InternshipRules
    {
        public const string EmptyOrNullProperty = "{PropertyName} is required and must be valid.";
        public const string InvalidMinDurationInMonths = "{PropertyName} is lower than expected";
        public const string InvalidMinInternsToEnrol = "{PropertyName} is lower than expected";
        public const string StatusNotAnEnumValue = "{PropertyName not in enum}";
        public const string InvalidStatusTransition = "{PropertyName} transition is not valid.";
    }
}