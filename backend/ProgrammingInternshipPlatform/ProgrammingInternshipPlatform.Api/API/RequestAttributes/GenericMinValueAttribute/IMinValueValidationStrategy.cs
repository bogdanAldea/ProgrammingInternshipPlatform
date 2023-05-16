using System.ComponentModel.DataAnnotations;

namespace ProgrammingInternshipPlatform.Api.API.RequestAttributes.GenericMinValueAttribute;

public interface IMinValueValidationStrategy
{
    ValidationResult? IsValid(object incomingValue, object minValue);
}