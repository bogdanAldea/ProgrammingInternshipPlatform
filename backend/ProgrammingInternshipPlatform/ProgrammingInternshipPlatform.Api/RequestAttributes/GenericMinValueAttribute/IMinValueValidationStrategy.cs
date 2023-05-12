using System.ComponentModel.DataAnnotations;

namespace ProgrammingInternshipPlatform.Api.RequestAttributes.GenericMinValueAttribute;

public interface IMinValueValidationStrategy
{
    ValidationResult? IsValid(object incomingValue, object minValue);
}