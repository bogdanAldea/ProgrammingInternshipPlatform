using ProgrammingInternshipPlatform.Domain.InternshipManagement.Internship;

namespace ProgrammingInternshipPlatform.Api.Contracts.InternshipContracts.Responses;

public class InternshipDetailsDto
{
    public Guid Id { get; set; }
    public Guid LocationId { get; set; }
    public TimeframeDetailsDto Timeframe { get; set; } = null!;
    public int Status { get; set; }
    public int MaximumInternsToEnroll { get; private set; }
    public int DurationInMonths { get; private set; }

    public static InternshipDetailsDto MapFromInternship(Internship internship)
    {
        return new InternshipDetailsDto()
        {
            Id = internship.Id.Value,
            LocationId = internship.LocationId.Value,
            Timeframe = new TimeframeDetailsDto()
            {
                ScheduledToStartOn = internship.Timeframe.ScheduledToStartOn,
                ScheduledToEndOn = internship.Timeframe.ScheduledToEndOn
            },
            Status = (int)internship.Status,
            MaximumInternsToEnroll = internship.MaximumInternsToEnroll,
            DurationInMonths = internship.DurationInMonths
        };
    }
}