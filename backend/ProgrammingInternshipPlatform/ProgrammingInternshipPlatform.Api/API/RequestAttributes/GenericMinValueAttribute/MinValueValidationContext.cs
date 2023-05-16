using System.ComponentModel.DataAnnotations;

namespace ProgrammingInternshipPlatform.Api.API.RequestAttributes.GenericMinValueAttribute;

public class MinValueValidationContext
{
    private readonly IMinValueValidationStrategy _validationStrategy;

    public MinValueValidationContext(IMinValueValidationStrategy strategy)
    {
        _validationStrategy = strategy;
    }

    public ValidationResult? IsValid(object incomingValue, object minValue)
    {
        return _validationStrategy.IsValid(incomingValue, minValue);
    }
}