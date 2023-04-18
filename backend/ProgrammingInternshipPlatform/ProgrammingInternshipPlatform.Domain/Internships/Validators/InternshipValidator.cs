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
            .WithMessage(RuleFailureMessages.InternshipRules.StatusNotAnEnumValue);

        RuleFor(internship => internship.Location)
            .NotEmpty()
            .WithMessage(RuleFailureMessages.InternshipRules.EmptyOrNullProperty);

        RuleFor(internship => internship.Timeframe)
            .NotEmpty()
            .WithMessage(RuleFailureMessages.InternshipRules.EmptyOrNullProperty);

        RuleFor(internship => internship.Status)
            .Must((internship, status) =>
            {
                switch (internship.Status)
                {
                    case InternshipStatus.SetupInProgress:
                        return status == InternshipStatus.ReadyToStart;
                    case InternshipStatus.ReadyToStart:
                        return status == InternshipStatus.Ongoing;
                    case InternshipStatus.Ongoing:
                        return status == InternshipStatus.Completed;
                    case InternshipStatus.Completed:
                        return false;
                    default:
                        return false;
                }
            })
            .WithMessage(RuleFailureMessages.InternshipRules.InvalidStatusTransition);
    }
}