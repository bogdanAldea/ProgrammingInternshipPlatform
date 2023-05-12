namespace ProgrammingInternshipPlatform.Application.ResultPattern;

public class ApplicationError
{
    private readonly List<string> _errors = new();
    private ApplicationError(ApplicationErrorType errorType, string? errorMessage)
    {
        ApplicationErrorType = errorType;
        ApplicationErrorMessage = errorMessage;
    }

    private ApplicationError(ApplicationErrorType errorType, List<string> errors)
    {
        ApplicationErrorType = errorType;
        errors.ForEach(error => _errors.Add(error));
    }
    
    public ApplicationErrorType ApplicationErrorType { get; private set; }
    public IReadOnlyCollection<string> Errors => _errors;
    public string? ApplicationErrorMessage { get; private set; }

    public static ApplicationError AddError(ApplicationErrorType errorType, string errorMessage) 
        => new(errorType, errorMessage);

    public static ApplicationError AddErrors(ApplicationErrorType errorType, List<string> errors)
        => new(errorType, errors);

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