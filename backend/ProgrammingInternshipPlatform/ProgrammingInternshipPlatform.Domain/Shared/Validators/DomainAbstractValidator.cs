using FluentValidation;
using ProgrammingInternshipPlatform.Domain.Shared.ErrorHandling.Exceptions;

namespace ProgrammingInternshipPlatform.Domain.Shared.Validators;

public abstract class DomainAbstractValidator<TEntity> : AbstractValidator<TEntity>
{
    public virtual async Task ValidateDomainModelAsync(TEntity entity, CancellationToken cancellationToken)
    {
        var validationResult = await ValidateAsync(entity, cancellationToken);
        if (validationResult.IsValid) { return; }
        var errorMessage = validationResult.Errors.FirstOrDefault()!.ErrorMessage;
        throw new DomainModelValidationException(errorMessage);
    }
}