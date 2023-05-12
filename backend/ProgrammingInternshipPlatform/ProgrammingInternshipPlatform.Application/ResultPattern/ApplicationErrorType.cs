namespace ProgrammingInternshipPlatform.Application.ResultPattern;

public enum ApplicationErrorType
{
    ResourceNotFoundFailure = 0,
    DomainValidationFailure = 1,
    AccessDeniedFailure = 2,
    UniqueConstraintFailure = 4,
    IdentityUserAlreadyExists = 5
}