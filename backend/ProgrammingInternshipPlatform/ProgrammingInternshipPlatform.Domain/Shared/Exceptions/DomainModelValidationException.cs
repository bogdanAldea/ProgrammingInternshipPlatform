namespace ProgrammingInternshipPlatform.Domain.Shared.Exceptions;

public class DomainModelValidationException : Exception
{
    public DomainModelValidationException() {}
    public DomainModelValidationException(string message) : base(message) {}
    public DomainModelValidationException(string message, Exception innerException) : base(message, innerException) {}
}