namespace ProgrammingInternshipPlatform.Domain.Shared.ErrorHandling.Exceptions;

public class InternAlreadyEnrolledException : Exception
{
    public InternAlreadyEnrolledException() {}
    public InternAlreadyEnrolledException(string message) : base(message) {}
    public InternAlreadyEnrolledException(string message, Exception innerException) : base(message, innerException) {}
}