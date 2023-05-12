using System.ComponentModel.DataAnnotations;
using ProgrammingInternshipPlatform.Api.RequestAttributes;

namespace ProgrammingInternshipPlatform.Api.Contracts.InternshipContracts.Requests;

public class InternshipRescheduleDto
{
    [Required]
    [ScheduleFromTomorrow]
    public DateTime RescheduledDate { get; set; }
}