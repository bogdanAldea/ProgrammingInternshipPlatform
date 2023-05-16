using System.ComponentModel.DataAnnotations;
using ProgrammingInternshipPlatform.Api.RequestAttributes;
using ProgrammingInternshipPlatform.Domain.Shared.Validators;

namespace ProgrammingInternshipPlatform.Api.InternshipManagement.Contracts.Requests;

public class InternshipPostDto
{
    [Required]
    public Guid CompanyId { get; set; }
    
    [Required]
    public Guid LocationId { get; set; }
    
    [Required]
    [MinValue(RuleConstants.InternshipConstants.MinInternsToEnrol)]
    public int MaximumInternsToEnroll { get; set; }
    
    [Required]
    [MinValue(RuleConstants.InternshipConstants.MinDurationInMonths)]
    public int DurationInMonths { get; set; }
    
    [Required]
    [ScheduleFromTomorrow]
    public DateTime ScheduledToStartOnDate { get; set; }
}