namespace ProgrammingInternshipPlatform.Application.ResultPattern;

public enum ApplicationErrorType
{
    ResourceNotFoundFailure = 0,
    DomainValidationFailure = 1,
    AccessDeniedFailure = 2,
    UniqueConstraintFailure = 4,
    IdentityUserAlreadyExistsFailure = 5,
    IdentityRegistrationFailure = 6,
    IdentityLoginPasswordFailure = 7,
    TransactionFailure = 8
}