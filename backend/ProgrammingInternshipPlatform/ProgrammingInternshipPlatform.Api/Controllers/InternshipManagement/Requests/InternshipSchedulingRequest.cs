using System.ComponentModel.DataAnnotations;

namespace ProgrammingInternshipPlatform.Api.Controllers.InternshipManagement.Requests;

public class InternshipSchedulingRequest
{
    [Required] public Guid CoordinatorId { get; set; }
    [Required] public DateTime ScheduledStartDate { get; set; }
    [Required] public int MaxInternsToEnroll { get; set; }
    [Required] public int DurationInMonths { get; set; }
}