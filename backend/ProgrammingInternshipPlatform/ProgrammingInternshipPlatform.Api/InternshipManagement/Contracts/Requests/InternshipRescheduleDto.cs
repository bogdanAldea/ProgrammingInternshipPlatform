using System.ComponentModel.DataAnnotations;
using ProgrammingInternshipPlatform.Api.API.RequestAttributes;

namespace ProgrammingInternshipPlatform.Api.InternshipManagement.Contracts.Requests;

public class InternshipRescheduleDto
{
    [Required]
    [ScheduleFromTomorrow]
    public DateTime RescheduledDate { get; set; }
}