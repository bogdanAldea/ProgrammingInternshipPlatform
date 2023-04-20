using System.ComponentModel.DataAnnotations;

namespace ProgrammingInternshipPlatform.Api.Contracts.InternshipContracts.Requests;

public class InternshipRescheduleDto
{
    [Required]
    public DateTime RescheduledDate { get; set; }
}