using System.ComponentModel.DataAnnotations;

namespace ProgrammingInternshipPlatform.Api.Account.Contracts.Requests;

public class UserAccountRegistration
{
    public UserAccountRegistration(string firstName, string lastName, 
        string email, string password, string? pictureUrl, Guid companyId, IReadOnlyList<string> roles)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Password = password;
        PictureUrl = pictureUrl;
        CompanyId = companyId;
        Roles = roles;
    }

    [Required]
    public string FirstName { get; }
    [Required]
    public string LastName { get; }
    [Required]
    public string Email { get; }
    [Required]
    public string Password { get; }
    public string? PictureUrl { get; }
    [Required]
    public Guid CompanyId { get; }
    [Required] 
    public IReadOnlyList<string> Roles { get; }
}