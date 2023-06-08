using System.ComponentModel.DataAnnotations;

namespace ProgrammingInternshipPlatform.Api.Account.Contracts.Requests;

public class UserAccountAuthentication
{
    public UserAccountAuthentication(string emailAddress, string password)
    {
        EmailAddress = emailAddress;
        Password = password;
    }
    [Required]
    [EmailAddress]
    public string EmailAddress { get; }
    [Required]
    public string Password { get; }
}