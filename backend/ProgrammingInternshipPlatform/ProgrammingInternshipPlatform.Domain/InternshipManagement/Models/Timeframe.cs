using ProgrammingInternshipPlatform.Domain.InternshipManagement.Identifiers;
using ProgrammingInternshipPlatform.Domain.InternshipManagement.Validators;

namespace ProgrammingInternshipPlatform.Domain.InternshipManagement.Models;

public class Timeframe
{
    public Timeframe() {}

    public TimeframeId Id { get; private set; }
    public InternshipId InternshipId { get; set; }
    public DateTime ScheduledToStartOn { get; private set; }
    public DateTime ScheduledToEndOn { get; private set; }

    public static async Task<Timeframe> ScheduleNewTimeframe(DateTime startDate, int durationInMonths, CancellationToken cancellationToken)
    {
        var timeframeValidator = new TimeframeValidator();
        var timeframe =  new Timeframe()
        {
            Id = new TimeframeId(Guid.NewGuid()),
            ScheduledToStartOn = startDate,
            ScheduledToEndOn = startDate.AddMonths(durationInMonths)
        };
        await timeframeValidator.ValidateDomainModelAsync(timeframe, cancellationToken);
        return timeframe;
    }

    public async Task RescheduleStartDate(DateTime rescheduledStartDate, CancellationToken cancellationToken)
    {
        var timeframeValidator = new TimeframeValidator();
        ScheduledToStartOn = rescheduledStartDate;
        ScheduledToEndOn = ScheduledToStartOn.AddMonths(3);
        await timeframeValidator.ValidateDomainModelAsync(this, cancellationToken);
    }
    
}