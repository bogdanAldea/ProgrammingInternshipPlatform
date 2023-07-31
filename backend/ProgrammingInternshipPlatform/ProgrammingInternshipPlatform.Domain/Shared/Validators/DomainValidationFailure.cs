namespace ProgrammingInternshipPlatform.Domain.Shared.Validators;

public class DomainValidationFailure
{
    public DomainValidationFailure(string propertyName, string errorMessage, object attemptedValue)
    {
        PropertyName = propertyName;
        ErrorMessage = errorMessage;
        AttemptedValue = attemptedValue;
    }
    public string PropertyName { get; }
    public string ErrorMessage { get; }
    public object AttemptedValue { get; }
}
