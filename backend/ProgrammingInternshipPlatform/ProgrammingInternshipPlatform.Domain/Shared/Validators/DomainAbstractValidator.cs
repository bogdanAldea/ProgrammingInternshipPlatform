using FluentValidation;
using FluentValidation.Internal;
using FluentValidation.Results;
using ProgrammingInternshipPlatform.Domain.Shared.ErrorHandling.Exceptions;

namespace ProgrammingInternshipPlatform.Domain.Shared.Validators;

public abstract class DomainAbstractValidator<TEntity> : AbstractValidator<TEntity>
{
    public async Task ValidateDomainModelAsync(TEntity entity, CancellationToken cancellationToken)
    {
        var validationResult = await ValidateAsync(entity, cancellationToken);
        if (validationResult.IsValid)
            return;

        var domainValidationFailure = CreateFailure(validationResult.Errors);
        throw new DomainModelValidationException(domainValidationFailure);
    }

    public async Task ValidateDomainModelAsync(TEntity entity, Action<ValidationStrategy<TEntity>> options,
        CancellationToken cancellationToken)
    {
        var validationResult = await ValidateAsync(ValidationContext<TEntity>.CreateWithOptions(entity, options),
            cancellationToken);
        if (validationResult.IsValid)
            return;

        var domainValidationFailures = CreateFailure(validationResult.Errors);
        throw new DomainModelValidationException(domainValidationFailures);
    }

    private IReadOnlyList<DomainValidationFailure> CreateFailure(List<ValidationFailure> validationFailures)
    {
        var domainValidationFailures = new List<DomainValidationFailure>();
        foreach (var failure in validationFailures)
        {
            var domainValidationFailure = new DomainValidationFailure(
                failure.PropertyName,
                failure.ErrorMessage,
                failure.AttemptedValue);
            domainValidationFailures.Add(domainValidationFailure);

        }

        return domainValidationFailures;
    }
}