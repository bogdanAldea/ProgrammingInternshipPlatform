using System.ComponentModel.DataAnnotations;

namespace ProgrammingInternshipPlatform.Api.InternshipHub.Contracts.Requests;

public class InternshipSetupRequest
{
    [Required]
    public int Center { get; init; }
    [Required]
    public int MaxInternsToEnroll { get; init; }
    [Required]
    public int DurationInMonths { get; init; }
    [Required]
    public DateTime ScheduledToStartOn { get; init; }
    public DateTime? EstimatedToEndOn { get; init; }
}