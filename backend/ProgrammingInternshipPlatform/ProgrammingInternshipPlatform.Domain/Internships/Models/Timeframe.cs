using ProgrammingInternshipPlatform.Domain.Internships.Identifiers;
using ProgrammingInternshipPlatform.Domain.Internships.Validators;

namespace ProgrammingInternshipPlatform.Domain.Internships.Models;

public class Timeframe
{
    public Timeframe() {}

    public TimeframeId Id { get; private set; }
    public InternshipId InternshipId { get; set; }
    public DateTime ScheduledToStartOn { get; private set; }
    public DateTime ScheduledToEndOn { get; private set; }

    public static async Task<Timeframe> ScheduleNewTimeframe(DateTime startDate, DateTime endDate)
    {
        var timeframeValidator = new TimeframeValidator();
        var timeframe =  new Timeframe()
        {
            Id = new TimeframeId(Guid.NewGuid()),
            ScheduledToStartOn = startDate,
            ScheduledToEndOn = endDate
        };
        await timeframeValidator.ValidateDomainModelAsync(timeframe);
        return timeframe;
    }
    
}