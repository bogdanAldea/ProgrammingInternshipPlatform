using System.ComponentModel.DataAnnotations;

namespace ProgrammingInternshipPlatform.Api.RequestAttributes.GenericMinValueAttribute;

public class DateTimeMinValueValidationStrategy : IMinValueValidationStrategy
{
    public ValidationResult? IsValid(object incomingValue, object minValue)
    {
        
        if (incomingValue is string incomingValueAsString && string.IsNullOrEmpty(incomingValueAsString))
        {
            return new ValidationResult("This field must not be an empty string.");
        }

        if ((DateTime)incomingValue < (DateTime)minValue)
        {
            return new ValidationResult($"The date must be further into the future.");
        }
        
        return ValidationResult.Success;
    }
}