namespace ProgrammingInternshipPlatform.Application.ResultPattern;

public class FailureReason
{
    private readonly List<string> _errors = new();
    private FailureReason(FailureType errorType, string? errorMessage)
    {
        FailureType = errorType;
        ApplicationErrorMessage = errorMessage;
    }

    private FailureReason(FailureType errorType, List<string> errors)
    {
        FailureType = errorType;
        errors.ForEach(error => _errors.Add(error));
    }
    
    public FailureType FailureType { get; private set; }
    public IReadOnlyCollection<string> Errors => _errors;
    public string? ApplicationErrorMessage { get; private set; }

    public static FailureReason AddError(FailureType errorType, string errorMessage) 
        => new(errorType, errorMessage);

    public static FailureReason AddErrors(FailureType errorType, List<string> errors)
        => new(errorType, errors);

    public static FailureReason NotFoundFailure(string errorMessage)
        => new(errorType: FailureType.ResourceNotFoundFailure, errorMessage: errorMessage);
    
    public static FailureReason AccessDeniedFailure(string errorMessage)
        => new(errorType: FailureType.AccessDeniedFailure, errorMessage: errorMessage);
    
    public static FailureReason DomainValidationFailure(string errorMessage)
        => new(errorType: FailureType.DomainValidationFailure, errorMessage: errorMessage);
    
    public static FailureReason UniqueConstraintFailure(string errorMessage)
        => new(errorType: FailureType.UniqueConstraintFailure, errorMessage: errorMessage);

    public static FailureReason IdentityUserAlreadyExists(string errorMessage)
        => new(errorType: FailureType.IdentityUserAlreadyExistsFailure, errorMessage: errorMessage);

    public static FailureReason IdentityRegistrationFailure(string errorMessage)
        => new(errorType: FailureType.IdentityRegistrationFailure, errorMessage: errorMessage);
    
    public static FailureReason IdentityLoginPasswordFailure(string errorMessage)
        => new(errorType: FailureType.IdentityLoginPasswordFailure, errorMessage: errorMessage);

    public static FailureReason TransactionFailure(string errorMessage)
        => new(errorType: FailureType.TransactionFailure, errorMessage: errorMessage);
}