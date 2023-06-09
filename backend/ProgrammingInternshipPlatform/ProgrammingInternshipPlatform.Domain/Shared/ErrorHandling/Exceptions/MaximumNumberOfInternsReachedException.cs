namespace ProgrammingInternshipPlatform.Domain.Shared.Exceptions;

public class MaximumNumberOfInternsReachedException : Exception
{
    public MaximumNumberOfInternsReachedException() {}
    public MaximumNumberOfInternsReachedException(string message) : base(message) {}
    public MaximumNumberOfInternsReachedException(string message, Exception innerException) : base(message, innerException) {}
}