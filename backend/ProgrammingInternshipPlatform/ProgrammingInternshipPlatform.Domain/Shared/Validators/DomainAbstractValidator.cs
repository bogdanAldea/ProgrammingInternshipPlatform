using FluentValidation;
using ProgrammingInternshipPlatform.Domain.Shared.Exceptions;

namespace ProgrammingInternshipPlatform.Domain.Shared.Validators;

public abstract class DomainAbstractValidator<TEntity> : AbstractValidator<TEntity>
{
    public virtual async Task ValidateDomainModelAsync(TEntity entity)
    {
        var validationResult = await ValidateAsync(entity);
        if (validationResult.IsValid) { return; }
        var errorMessage = validationResult.Errors.FirstOrDefault()!.ErrorMessage;
        throw new DomainModelValidationException(errorMessage);
    }
}