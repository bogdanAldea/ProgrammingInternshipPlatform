using ProgrammingInternshipPlatform.Domain.InternshipManagement.Internships;

namespace ProgrammingInternshipPlatform.Application.InternshipManagement.GetInternshipSettings.Responses;

public class InternshipSettings
{
    public Guid Id { get; set; }
    public InternshipStatus Status { get; }
    public int MaximumInternsToEnroll { get; }
    public int DurationInMonths { get; }
    public DateTime ScheduledToStartOn { get; }
    public DateTime ScheduledToEndOn { get; }
    public string Center { get; }

    public InternshipSettings(Guid id, InternshipStatus status, int maximumInternsToEnroll, int durationInMonths,
        DateTime scheduledToStartOn, DateTime scheduledToEndOn, string center)
    {
        Id = id;
        Status = status;
        MaximumInternsToEnroll = maximumInternsToEnroll;
        DurationInMonths = durationInMonths;
        ScheduledToStartOn = scheduledToStartOn;
        ScheduledToEndOn = scheduledToEndOn;
        Center = center;
    }
}