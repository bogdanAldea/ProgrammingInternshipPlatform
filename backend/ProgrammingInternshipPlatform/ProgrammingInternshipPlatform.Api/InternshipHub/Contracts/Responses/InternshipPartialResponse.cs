using ProgrammingInternshipPlatform.Domain.InternshipHub.Internships.Enums;
using ProgrammingInternshipPlatform.Domain.InternshipHub.Internships.Identifiers;
using ProgrammingInternshipPlatform.Domain.InternshipHub.Internships.Models;

namespace ProgrammingInternshipPlatform.Api.InternshipHub.Contracts.Responses;

public class InternshipPartialResponse
{
    public Guid Id { get; private set; }
    public InternshipStatus Status { get; private set; }
    public Center Center { get; private set; }
    public DateTime ScheduledToStartOn { get; private set; }
    public DateTime EstimatedToEndOn { get; private set; }
    public int DurationInMonths { get; private set; }
    public int MaxInternsToEnroll { get; private set; }

    public static InternshipPartialResponse MapResource(Internship internship)
    {
        return new InternshipPartialResponse
        {
            Id = internship.Id.Value,
            Status = internship.Status,
            Center = internship.Center,
            ScheduledToStartOn = internship.ScheduledToStartOn,
            EstimatedToEndOn = internship.EstimatedToEndOn,
            DurationInMonths = internship.DurationInMonths,
            MaxInternsToEnroll = internship.MaxInternsToEnroll
        };
    }
}