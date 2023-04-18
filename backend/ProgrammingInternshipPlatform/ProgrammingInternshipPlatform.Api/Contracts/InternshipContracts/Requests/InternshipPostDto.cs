namespace ProgrammingInternshipPlatform.Api.Contracts.InternshipContracts.Requests;

public class InternshipPostDto
{
    public Guid LocationId { get; set; }
    public int MaximumInternsToEnroll { get; set; }
    public int DurationInMonths { get; set; }
    public DateTime ScheduledToStartOnDate { get; set; }
    public DateTime ScheduledToEndOnDate { get; set; }
}