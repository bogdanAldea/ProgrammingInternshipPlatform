namespace ProgrammingInternshipPlatform.Domain.Shared.ErrorHandling.Exceptions;

public class DomainModelValidationException : Exception
{
    public DomainModelValidationException() {}
    public DomainModelValidationException(string message) : base(message) {}
    public DomainModelValidationException(string message, Exception innerException) : base(message, innerException) {}
}