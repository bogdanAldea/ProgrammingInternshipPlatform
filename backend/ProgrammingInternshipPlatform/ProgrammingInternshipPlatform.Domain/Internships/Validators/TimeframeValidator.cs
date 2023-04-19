using FluentValidation;
using ProgrammingInternshipPlatform.Domain.Internships.Models;
using ProgrammingInternshipPlatform.Domain.Shared.Validators;

namespace ProgrammingInternshipPlatform.Domain.Internships.Validators;

public class TimeframeValidator : DomainAbstractValidator<Timeframe>
{
    public TimeframeValidator()
    {
        RuleFor(timeframe => timeframe.ScheduledToStartOn)
            .NotEmpty()
            .WithMessage(RuleFailureMessages.TimeframeMessages.EmptyOrNullProperty)
            .Must(startDate => startDate >= DateTime.Today)
            .WithMessage(RuleFailureMessages.TimeframeMessages.StartDateSetInThePast);

        RuleFor(timeframe => timeframe.ScheduledToEndOn)
            .NotEmpty()
            .WithMessage(RuleFailureMessages.TimeframeMessages.EmptyOrNullProperty)
            .Must((timeframe, endDate) => endDate > timeframe.ScheduledToStartOn)
            .WithMessage(RuleFailureMessages.TimeframeMessages.EndDateEqualOrLowerThanStartDate);
    }
}