namespace ProgrammingInternshipPlatform.Application.ResultPattern;

public enum FailureType
{
    ResourceNotFoundFailure = 1,
    InternalServerFailure,
    DomainValidationFailure,
    SqlFailure,
    TransactionFailure,
}