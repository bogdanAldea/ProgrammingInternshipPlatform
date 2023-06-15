using ProgrammingInternshipPlatform.Domain.InternshipManagement.Interns;
using ProgrammingInternshipPlatform.Domain.InternshipManagement.Internships;
using ProgrammingInternshipPlatform.Domain.InternshipManagement.Mentorships;
using ProgrammingInternshipPlatform.Domain.InternshipManagement.Timeframes;
using ProgrammingInternshipPlatform.Domain.InternshipManagement.Trainers;

namespace ProgrammingInternshipPlatform.Api.Organisation.Contracts.Responses;

public class InternshipDetail
{
    public Guid Id { get; set; }
    public DateTime ScheduledToStartOn { get; set; }
    public DateTime ScheduledToEndOn { get; set; }
    public InternshipStatus Status { get; set; }
    public int NumberOfInterns { get; set; }
    public int MaximumInternsToEnroll { get; private set; }
    public int DurationInMonths { get; private set; }
    
    public static InternshipDetail MapFromInternship(Internship internship)
    {
        return new InternshipDetail
        {
            Id = internship.Id.Value,
            ScheduledToStartOn = internship.Timeframe.ScheduledToStartOn,
            ScheduledToEndOn = internship.Timeframe.ScheduledToEndOn,
            Status = internship.Status,
            NumberOfInterns = internship.Interns.Count,
            MaximumInternsToEnroll = internship.MaximumInternsToEnroll,
            DurationInMonths = internship.DurationInMonths
        };
    }
}