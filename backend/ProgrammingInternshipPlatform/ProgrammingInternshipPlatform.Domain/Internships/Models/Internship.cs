using ProgrammingInternshipPlatform.Domain.Internships.Enums;
using ProgrammingInternshipPlatform.Domain.Internships.Identifiers;
using ProgrammingInternshipPlatform.Domain.Locations.Models;

namespace ProgrammingInternshipPlatform.Domain.Internships.Models;

public class Internship
{
    public Internship(InternshipId id, int maximumInternsToEnroll, int durationInMonths, Location location)
    {
        Id = id;
        MaximumInternsToEnroll = maximumInternsToEnroll;
        DurationInMonths = durationInMonths;
        Location = location;
    }
    
    public Internship(InternshipId id, int maximumInternsToEnroll, int durationInMonths,
        DateTime scheduledToStartOnDate, DateTime scheduledToEndOnDate, Location location)
    {
        Id = id;
        MaximumInternsToEnroll = maximumInternsToEnroll;
        DurationInMonths = durationInMonths;
        ScheduledToStartOnDate = scheduledToStartOnDate;
        ScheduledToEndOnDate = scheduledToEndOnDate;
        Location = location;
    }

    public InternshipId Id { get; private set; }
    public InternshipStatus Status { get; private set; } = InternshipStatus.NotStarted;
    public int MaximumInternsToEnroll { get; private set; }
    public int DurationInMonths { get; set; }
    public DateTime? ScheduledToStartOnDate { get; private set; }
    public DateTime? ScheduledToEndOnDate { get; private set; }
    public Location Location { get; set; }
}