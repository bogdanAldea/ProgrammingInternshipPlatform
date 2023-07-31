using ProgrammingInternshipPlatform.Domain.Shared.Validators;

namespace ProgrammingInternshipPlatform.Domain.Shared.ErrorHandling.Exceptions;

public class DomainModelValidationException : Exception
{
    public DomainModelValidationException(DomainValidationFailure failure)
    {
        DomainValidationFailure = failure;
    }
    public DomainModelValidationException(string message) : base(message) {}
    public DomainModelValidationException(string message, Exception innerException) : base(message, innerException) {}

    public DomainValidationFailure? DomainValidationFailure { get; set; }
}