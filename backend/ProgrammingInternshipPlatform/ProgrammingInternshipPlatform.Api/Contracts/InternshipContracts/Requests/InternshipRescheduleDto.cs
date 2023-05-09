using System.ComponentModel.DataAnnotations;
using ProgrammingInternshipPlatform.Api.RequestAttributes;
using ProgrammingInternshipPlatform.Domain.Shared.Validators;

namespace ProgrammingInternshipPlatform.Api.Contracts.InternshipContracts.Requests;

public class InternshipRescheduleDto
{
    [Required]
    public DateTime RescheduledDate { get; set; }
}