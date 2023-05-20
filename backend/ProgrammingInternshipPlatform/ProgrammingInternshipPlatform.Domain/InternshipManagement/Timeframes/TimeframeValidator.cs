using FluentValidation;
using ProgrammingInternshipPlatform.Domain.Shared.Validators;

namespace ProgrammingInternshipPlatform.Domain.InternshipManagement.Timeframes;

public class TimeframeValidator : DomainAbstractValidator<Timeframe>
{
    public TimeframeValidator()
    {
        RuleFor(timeframe => timeframe.ScheduledToStartOn)
            .Cascade(CascadeMode.Stop)
            .NotEmpty()
            .WithMessage(RuleFailureMessages.TimeframeMessages.EmptyOrNullProperty)
            .Must(startDate => startDate >= DateTime.Today)
            .WithMessage(RuleFailureMessages.TimeframeMessages.StartDateSetInThePast);

        RuleFor(timeframe => timeframe.ScheduledToEndOn)
            .Cascade(CascadeMode.Stop)
            .NotEmpty()
            .WithMessage(RuleFailureMessages.TimeframeMessages.EmptyOrNullProperty)
            .Must((timeframe, endDate) => endDate > timeframe.ScheduledToStartOn)
            .WithMessage(RuleFailureMessages.TimeframeMessages.EndDateEqualOrLowerThanStartDate);
    }
}