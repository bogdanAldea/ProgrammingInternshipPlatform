using FluentValidation;
using ProgrammingInternshipPlatform.Domain.Internships.Enums;
using ProgrammingInternshipPlatform.Domain.Internships.Models;
using ProgrammingInternshipPlatform.Domain.Shared.Validators;

namespace ProgrammingInternshipPlatform.Domain.Internships.Validators;

public class InternshipValidator : DomainAbstractValidator<Internship>
{
    public InternshipValidator()
    {
        RuleFor(internship => internship.DurationInMonths)
            .NotEmpty()
            .WithMessage(RuleFailureMessages.InternshipRules.EmptyOrNullProperty)
            .Must(durationInMonths => durationInMonths > RuleConstants.InternshipConstants.MinDurationInMonths)
            .WithMessage(RuleFailureMessages.InternshipRules.InvalidMinDurationInMonths);

        RuleFor(internship => internship.MaximumInternsToEnroll)
            .NotEmpty()
            .WithMessage(RuleFailureMessages.InternshipRules.EmptyOrNullProperty)
            .Must(maxEnrolledInterns => maxEnrolledInterns > RuleConstants.InternshipConstants.MinInternsToEnrol)
            .WithMessage(RuleFailureMessages.InternshipRules.InvalidMinInternsToEnrol);

        RuleFor(internship => internship.Status)
            .NotEmpty()
            .WithMessage(RuleFailureMessages.InternshipRules.EmptyOrNullProperty)
            .IsInEnum()
            .WithMessage(RuleFailureMessages.InternshipRules.StatusNotAnEnumValue)
            .Equal(InternshipStatus.SetupInProgress)
            .WithMessage(RuleFailureMessages.InternshipRules.InvalidStatusAtCreation);;

        RuleFor(internship => internship.LocationId)
            .NotEmpty()
            .WithMessage(RuleFailureMessages.InternshipRules.EmptyOrNullProperty);

        RuleFor(internship => internship.Timeframe)
            .NotEmpty()
            .WithMessage(RuleFailureMessages.InternshipRules.EmptyOrNullProperty);
    }
}