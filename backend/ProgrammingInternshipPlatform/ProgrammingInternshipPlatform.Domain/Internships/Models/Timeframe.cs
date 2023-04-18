using ProgrammingInternshipPlatform.Domain.Internships.Identifiers;

namespace ProgrammingInternshipPlatform.Domain.Internships.Models;

public class Timeframe
{
    public Timeframe() {}

    public TimeframeId Id { get; private set; }
    public InternshipId InternshipId { get; set; }
    public DateTime ScheduledToStartOn { get; private set; }
    public DateTime ScheduledToEndOn { get; private set; }
}