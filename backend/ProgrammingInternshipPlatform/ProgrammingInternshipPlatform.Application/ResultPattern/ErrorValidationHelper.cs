namespace ProgrammingInternshipPlatform.Application.ResultPattern;

public class ErrorValidationHelper
{
    private ErrorValidationHelper(string errorMessage)
    {
        ErrorMessage = errorMessage;
    }
    public string ErrorMessage { get; }

    public static HandlerResult<T> NotFoundFailure<T>(string message)
    {
        var applicationError = ApplicationError.NotFoundFailure(message);
        return HandlerResult<T>.Fail(applicationError);
    }
    
    public static HandlerResult<T> TransactionFailure<T>(string message)
    {
        var applicationError = ApplicationError.TransactionFailure(message);
        return HandlerResult<T>.Fail(applicationError);
    }
    
    public static HandlerResult<T> DomainValidationFailure<T>(string message)
    {
        var applicationError = ApplicationError.DomainValidationFailure(message);
        return HandlerResult<T>.Fail(applicationError);
    }

    public static HandlerResult<T> LoginPasswordFailure<T>(string message)
    {
        var applicationError = ApplicationError.IdentityLoginPasswordFailure(message);
        return HandlerResult<T>.Fail(applicationError);
    }
}