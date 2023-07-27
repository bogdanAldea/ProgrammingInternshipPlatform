using System.ComponentModel.DataAnnotations;

namespace ProgrammingInternshipPlatform.Api.Accounts.Contracts.Requests;

public class UserAccountAuthentication
{
    public UserAccountAuthentication(string email, string password)
    {
        Email = email;
        Password = password;
    }
    [Required]
    [EmailAddress]
    public string Email { get; }
    [Required]
    public string Password { get; }
}