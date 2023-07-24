using ProgrammingInternshipPlatform.Domain.InternshipManagement.Internships;

namespace ProgrammingInternshipPlatform.Application.InternshipManagement.Responses;

public class FullInternshipResponse
{
    public Guid Id { get; private set; }
    public InternshipStatus Status { get; private set; }
    public int MaximumInternsToEnroll { get; private set; }
    public int DurationInMonths { get; private set; }
    public DateTime ScheduledToStartOn { get; private set; }
    public DateTime ScheduledToEndOn { get; private set; }
    public string Center { get; private set; } = null!;

    public static FullInternshipResponse MapFromInternshipQueryResult(Internship internship, string center)
    {
        return new FullInternshipResponse
        {
            Id = internship.Id.Value,
            Status = internship.Status,
            MaximumInternsToEnroll = internship.MaximumInternsToEnroll,
            DurationInMonths = internship.DurationInMonths,
            ScheduledToStartOn = internship.Timeframe.ScheduledToStartOn,
            ScheduledToEndOn = internship.Timeframe.ScheduledToEndOn,
            Center = center
        };
    }
}