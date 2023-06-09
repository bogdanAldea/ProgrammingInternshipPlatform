﻿using FluentValidation;
using ProgrammingInternshipPlatform.Domain.Shared.Validators;

namespace ProgrammingInternshipPlatform.Domain.InternshipManagement.Internships;

public class InternshipValidator : DomainAbstractValidator<Internship>
{
    public InternshipValidator()
    {
        RuleFor(internship => internship.DurationInMonths)
            .NotEmpty()
            .WithMessage(RuleFailureMessages.InternshipMessages.EmptyOrNullProperty)
            .Must(durationInMonths => durationInMonths > RuleConstants.InternshipConstants.MinDurationInMonths)
            .WithMessage(RuleFailureMessages.InternshipMessages.InvalidMinDurationInMonths);

        RuleFor(internship => internship.MaximumInternsToEnroll)
            .NotEmpty()
            .WithMessage(RuleFailureMessages.InternshipMessages.EmptyOrNullProperty)
            .Must(maxEnrolledInterns => maxEnrolledInterns > RuleConstants.InternshipConstants.MinInternsToEnrol)
            .WithMessage(RuleFailureMessages.InternshipMessages.InvalidMinInternsToEnrol);

        RuleFor(internship => internship.Status)
            .NotEmpty()
            .WithMessage(RuleFailureMessages.InternshipMessages.EmptyOrNullProperty)
            .IsInEnum()
            .WithMessage(RuleFailureMessages.InternshipMessages.StatusNotAnEnumValue)
            .Equal(InternshipStatus.SetupInProgress)
            .WithMessage(RuleFailureMessages.InternshipMessages.InvalidStatusAtCreation);;

        RuleFor(internship => internship.CenterId)
            .NotEmpty()
            .WithMessage(RuleFailureMessages.InternshipMessages.EmptyOrNullProperty);

        RuleFor(internship => internship.Timeframe)
            .NotEmpty()
            .WithMessage(RuleFailureMessages.InternshipMessages.EmptyOrNullProperty);
    }
}