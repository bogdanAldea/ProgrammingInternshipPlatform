namespace ProgrammingInternshipPlatform.Application.ResultPattern.FailureReason;

public class FailureReason<TFailure>
{
    private readonly List<TFailure> _failures = new();
    private FailureReason(FailureType failureType, TFailure failure)
    {
        FailureType = failureType;
        Failure = failure;
    }

    private FailureReason(FailureType failureType, IReadOnlyList<TFailure> failures)
    {
        FailureType = failureType;
        failures.ToList().ForEach(error => _failures.Add(error));
    }
    
    public FailureType FailureType { get; private set; }
    public IReadOnlyList<TFailure> Failures => _failures;
    public TFailure? Failure { get; private set; }

    public static FailureReason<TFailure> DomainValidationFailure(TFailure failure)
        => new(failureType: FailureType.DomainValidationFailure, failure: failure);
    
    public static FailureReason<TFailure> DomainValidationFailure(IReadOnlyList<TFailure> failures)
        => new(failureType: FailureType.DomainValidationFailure, failures: failures);
    
    public static FailureReason<TFailure> NotFoundFailure(TFailure failure)
        => new(failureType: FailureType.ResourceNotFoundFailure, failure: failure);
    
    public static FailureReason<TFailure> InternalServerFailure(TFailure failure)
        => new(failureType: FailureType.InternalServerFailure, failure: failure);

    public static FailureReason<TFailure> AddFailures(FailureType failureType, IReadOnlyList<TFailure> failures)
        => new(failureType: failureType, failures: failures);
}