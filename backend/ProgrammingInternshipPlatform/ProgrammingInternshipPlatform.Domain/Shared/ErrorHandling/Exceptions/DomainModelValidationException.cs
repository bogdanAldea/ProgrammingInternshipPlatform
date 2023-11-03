using ProgrammingInternshipPlatform.Domain.Shared.Validators;

namespace ProgrammingInternshipPlatform.Domain.Shared.ErrorHandling.Exceptions;

public class DomainModelValidationException : Exception
{
    private readonly List<DomainValidationFailure> _validationFailures = new();
    public DomainModelValidationException(DomainValidationFailure failure)
    {
        DomainValidationFailure = failure;
    }
    
    public DomainModelValidationException(IReadOnlyList<DomainValidationFailure> failures)
    {
        foreach (var failure in failures)
        {
            _validationFailures.Add(failure);
        }
    }
    
    public DomainModelValidationException(string message) : base(message) {}
    public DomainModelValidationException(string message, Exception innerException) : base(message, innerException) {}

    public DomainValidationFailure? DomainValidationFailure { get; set; }
    public IReadOnlyList<DomainValidationFailure> DomainValidationFailures => _validationFailures;
}