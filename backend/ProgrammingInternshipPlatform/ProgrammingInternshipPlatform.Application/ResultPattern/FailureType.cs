namespace ProgrammingInternshipPlatform.Application.ResultPattern;

public enum FailureType
{
    ResourceNotFoundFailure = 1,
    DomainValidationFailure,
    SqlFailure,
    TransactionFailure,
}