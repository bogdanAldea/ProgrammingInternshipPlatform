using System.ComponentModel.DataAnnotations;

namespace ProgrammingInternshipPlatform.Api.API.RequestAttributes.GenericMinValueAttribute;

public class IntMinValueValidationStrategy : IMinValueValidationStrategy
{
    public ValidationResult? IsValid(object incomingValue, object minValue)
    {
        return (int)incomingValue >= (int)minValue ? 
            ValidationResult.Success : 
            new ValidationResult($"The field must have a minimum value of {minValue}.");
    }
}