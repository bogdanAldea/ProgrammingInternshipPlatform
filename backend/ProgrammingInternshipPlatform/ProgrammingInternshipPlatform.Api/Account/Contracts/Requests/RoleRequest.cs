using System.ComponentModel.DataAnnotations;

namespace ProgrammingInternshipPlatform.Api.Account.Contracts.Requests;

public class RoleRequest
{
    [Required]
    public string Name { get; set; } = null!;
    [Required]
    public string Id { get; set; } = null!;
}