using System.ComponentModel.DataAnnotations;

namespace ProgrammingInternshipPlatform.Api.RequestAttributes;

// Investigate generics here(datetime)
public class MinValueAttribute : ValidationAttribute
{
    private readonly int _maxValue;

    public MinValueAttribute(int maxValue)
    {
        _maxValue = maxValue;
    }

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is not null)
        {
            if (int.TryParse(value.ToString(), out var intValue))
            {
                if (intValue < _maxValue)
                {
                    return new ValidationResult(
                        $"The field {validationContext.DisplayName} must " +
                        $"be greater than or equal to {_maxValue}.");
                }
            }
        }
        return ValidationResult.Success;
    }
}