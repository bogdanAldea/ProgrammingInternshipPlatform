namespace ProgrammingInternshipPlatform.Application.ResultPattern;

public class ApplicationError
{
    private ApplicationError(ApplicationErrorType errorType, string errorMessage)
    {
        ApplicationErrorType = errorType;
        ApplicationErrorMessage = errorMessage;
    }
    public ApplicationErrorType ApplicationErrorType { get; private set; }
    public string ApplicationErrorMessage { get; private set; }

    public static ApplicationError AddError(ApplicationErrorType errorType, string errorMessage) =>
         new(errorType, errorMessage);

    public static ApplicationError NotFoundFailure(string errorMessage)
        => new(errorType: ApplicationErrorType.ResourceNotFoundFailure, errorMessage: errorMessage);
    
    public static ApplicationError AccessDeniedFailure(string errorMessage)
        => new(errorType: ApplicationErrorType.AccessDeniedFailure, errorMessage: errorMessage);
    
    public static ApplicationError DomainValidationFailure(string errorMessage)
        => new(errorType: ApplicationErrorType.DomainValidationFailure, errorMessage: errorMessage);
    
    public static ApplicationError UniqueConstraintFailure(string errorMessage)
        => new(errorType: ApplicationErrorType.UniqueConstraintFailure, errorMessage: errorMessage);

    public static ApplicationError IdentityUserAlreadyExists(string errorMessage)
        => new(errorType: ApplicationErrorType.IdentityUserAlreadyExists, errorMessage: errorMessage);
}