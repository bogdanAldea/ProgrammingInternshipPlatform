using System.ComponentModel.DataAnnotations;

namespace ProgrammingInternshipPlatform.Api.InternshipManagement.Contracts.Requests;

public class InternEnrollment
{
    public InternEnrollment(Guid userAccountId)
    {
        UserAccountId = userAccountId;
    }
    [Required]
    public Guid UserAccountId { get; }
}