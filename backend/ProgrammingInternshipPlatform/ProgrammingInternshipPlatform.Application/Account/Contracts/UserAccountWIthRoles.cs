namespace ProgrammingInternshipPlatform.Application.Account.Contracts;

public class UserAccountWIthRoles
{
    public Guid Id { get; set; }
    public Guid IdentityId { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string? PictureUrl { get; set; }
    public DateTime JoiningDate { get; set; }
    public List<UserAccountRole> Roles { get; set; } = new();
}