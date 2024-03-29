﻿using FluentValidation;
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

    private DomainValidationFailure CreateFailure(List<ValidationFailure> validationFailures)
    {
        return validationFailures.Select(failure => new DomainValidationFailure(
                failure.PropertyName, 
                failure.ErrorMessage, 
                failure.AttemptedValue)
            )
            .Single();
    }
}