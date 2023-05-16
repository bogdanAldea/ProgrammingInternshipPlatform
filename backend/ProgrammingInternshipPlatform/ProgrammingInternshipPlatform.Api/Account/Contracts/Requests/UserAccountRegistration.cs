using System.ComponentModel.DataAnnotations;

namespace ProgrammingInternshipPlatform.Api.Account.Contracts.Requests;

public class UserAccountRegistration
{
    public UserAccountRegistration(string firstName, string lastName, 
        string email, string password, string? pictureUrl, Guid companyId)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Password = password;
        PictureUrl = pictureUrl;
        CompanyId = companyId;
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
}