using System.ComponentModel.DataAnnotations;

namespace ProgrammingInternshipPlatform.Api.Account.Contracts.Requests;

public class AdminAccountRegistration
{
    public AdminAccountRegistration(string firstName, string lastName,
        string email, string password, string? pictureUrl, IReadOnlyList<string> roles)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Password = password;
        PictureUrl = pictureUrl;
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
    public IReadOnlyList<string> Roles { get; }
}