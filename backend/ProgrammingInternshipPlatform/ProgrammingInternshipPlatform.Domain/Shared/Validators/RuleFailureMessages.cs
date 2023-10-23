namespace ProgrammingInternshipPlatform.Domain.Shared.Validators;

public static class RuleFailureMessages
{
    public const string PropertyMustExist = "{PropertyName} cannot be null and must be valid.";
    public const string PropertyMustBeAEnumValue = "{PropertyName} must a valid enum value";
    public const string PropertyLenghtTooLong = "{PropertyName} must not exceed {MaxLenght} characters";
    public const string PropertyMustBePositiveNumber = "{PropertyName} must be greater than 0";
    public const string CollectionMustNotBeEmpty = "At least one {PropertyName} must be added.";
    public const string CollectionItemsMustHaveUniqueTitle = "There cannot be more {PropertyName} with the same title.";
    public const string PropertyMustBeInValidState = "{PropertyName} of Topic must be {PropertyValue}";
}