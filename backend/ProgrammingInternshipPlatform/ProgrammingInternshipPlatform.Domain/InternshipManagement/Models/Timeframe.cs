using ProgrammingInternshipPlatform.Domain.InternshipManagement.Identifiers;
using ProgrammingInternshipPlatform.Domain.InternshipManagement.Validators;
using ProgrammingInternshipPlatform.Domain.Shared.Exceptions;

namespace ProgrammingInternshipPlatform.Domain.InternshipManagement.Models;

public class Timeframe
{
    public Timeframe()
    {
    }

    public TimeframeId Id { get; private set; }
    public InternshipId InternshipId { get; set; }
    public DateTime ScheduledToStartOn { get; private set; }
    public DateTime ScheduledToEndOn { get; private set; }

    public static async Task<Timeframe> ScheduleNewTimeframe(DateTime startDate, int durationInMonths,
        CancellationToken cancellationToken)
    {
        var timeframeValidator = new TimeframeValidator();
        var timeframe = new Timeframe()
        {
            Id = new TimeframeId(Guid.NewGuid()),
            ScheduledToStartOn = startDate,
            ScheduledToEndOn = startDate.AddMonths(durationInMonths)
        };
        await timeframeValidator.ValidateDomainModelAsync(timeframe, cancellationToken);
        return timeframe;
    }

    public async Task RescheduleStartDate(DateTime rescheduledStartDate, int durationInMonths,
        CancellationToken cancellationToken)
    {
        var timeframeValidator = new TimeframeValidator();
        ScheduledToStartOn = rescheduledStartDate;
        ScheduledToEndOn = ScheduledToStartOn.AddMonths(durationInMonths);
        await timeframeValidator.ValidateDomainModelAsync(this, cancellationToken);
    }

    public async Task ExtendEndDate(DateTime extendedEndDate, int durationInMonths, CancellationToken cancellationToken)
    {
        var timeframeValidator = new TimeframeValidator();
        if (extendedEndDate < ScheduledToStartOn.AddMonths(durationInMonths))
        {
            throw new DomainModelValidationException(
                $"The estimated end date must be set at least the number of " +
                $"months({durationInMonths}) apart from the previously set start date of the internship.");
        }

        ScheduledToEndOn = extendedEndDate;
        await timeframeValidator.ValidateDomainModelAsync(this, cancellationToken);
    }
}