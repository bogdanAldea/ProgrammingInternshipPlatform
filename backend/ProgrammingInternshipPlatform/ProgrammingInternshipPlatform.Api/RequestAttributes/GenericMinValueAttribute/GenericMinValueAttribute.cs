using System.ComponentModel.DataAnnotations;

namespace ProgrammingInternshipPlatform.Api.RequestAttributes.GenericMinValueAttribute;

public class GenericMinValueAttribute<T> : ValidationAttribute
{
    private readonly T _minValue;
    private readonly MinValueValidationContext _validationContext;

    public GenericMinValueAttribute(T minValue)
    {
        _minValue = minValue;
        
        IMinValueValidationStrategy validationStrategy;
        if (typeof(T) == typeof(int))
        {
            validationStrategy = new IntMinValueValidationStrategy();
        }
        else if (typeof(T) == typeof(DateTime))
        {
            validationStrategy = new DateTimeMinValueValidationStrategy();
        }
        else
        {
            throw new InvalidOperationException($"The attribute does not support type {typeof(T).Name}.");
        }

        _validationContext = new MinValueValidationContext(validationStrategy);
    }

    protected override ValidationResult? IsValid(object? incomingValue, ValidationContext validationContext)
    {
        if (incomingValue is null) return new ValidationResult("The field must have a value.");
        return _validationContext.IsValid(incomingValue, _minValue!);
    } 
}