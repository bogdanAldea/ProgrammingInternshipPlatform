namespace ProgrammingInternshipPlatform.Domain.Shared.ErrorHandling.Exceptions;

public class InternshipAlreadySetupException : Exception
{
    public InternshipAlreadySetupException() {}
    public InternshipAlreadySetupException(string message) : base(message) {}
    public InternshipAlreadySetupException(string message, Exception innerException) : base(message, innerException) {}
}
