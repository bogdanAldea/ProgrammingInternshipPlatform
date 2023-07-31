namespace ProgrammingInternshipPlatform.Application.ResultPattern;

public class HandlerResultFailureHelper
{
    private HandlerResultFailureHelper(string errorMessage)
    {
        ErrorMessage = errorMessage;
    }
    public string ErrorMessage { get; }

    public static HandlerResult<T> NotFoundFailure<T>(string message)
    {
        var applicationError = FailureReason.NotFoundFailure(message);
        return HandlerResult<T>.Fail(applicationError);
    }
    
    public static HandlerResult<T> TransactionFailure<T>(string message)
    {
        var applicationError = FailureReason.TransactionFailure(message);
        return HandlerResult<T>.Fail(applicationError);
    }
    
    public static HandlerResult<T> DomainValidationFailure<T>(string message)
    {
        var applicationError = FailureReason.DomainValidationFailure(message);
        return HandlerResult<T>.Fail(applicationError);
    }
}