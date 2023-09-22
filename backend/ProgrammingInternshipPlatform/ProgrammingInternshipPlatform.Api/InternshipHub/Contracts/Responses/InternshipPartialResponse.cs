using ProgrammingInternshipPlatform.Application.Helpers.EnumRetrieval;
using ProgrammingInternshipPlatform.Domain.InternshipHub.Internships.Enums;
using ProgrammingInternshipPlatform.Domain.InternshipHub.Internships.Models;

namespace ProgrammingInternshipPlatform.Api.InternshipHub.Contracts.Responses;

public class InternshipPartialResponse
{
    public Guid InternshipId { get; private set; }
    public DomainEnumConverted<InternshipStatus> Status { get; private set; } = null!;
    public DomainEnumConverted<Center> Center { get; private set; } = null!;
    public DateTime ScheduledToStartOn { get; private set; }
    public DateTime EstimatedToEndOn { get; private set; }
    public int DurationInMonths { get; private set; }
    public int MaxInternsToEnroll { get; private set; }

    public static InternshipPartialResponse MapFrom(Internship internship)
    {
        return new InternshipPartialResponse
        {
            InternshipId = internship.Id.Value,
            Status = EnumRetrievalHelper.ConvertEnumValue(internship.Status),
            Center = EnumRetrievalHelper.ConvertEnumValue(internship.Center),
            ScheduledToStartOn = internship.ScheduledToStartOn,
            EstimatedToEndOn = internship.EstimatedToEndOn,
            DurationInMonths = internship.DurationInMonths,
            MaxInternsToEnroll = internship.MaxInternsToEnroll
        };
    }
}