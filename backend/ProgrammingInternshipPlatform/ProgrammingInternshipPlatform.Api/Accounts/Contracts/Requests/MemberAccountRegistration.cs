using System.ComponentModel.DataAnnotations;

namespace ProgrammingInternshipPlatform.Api.Accounts.Contracts.Requests;

public class MemberAccountRegistration
{
    public MemberAccountRegistration(string firstName, string lastName, string email, Guid companyId, IReadOnlyList<string> roles)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        CompanyId = companyId;
        Roles = roles;
    }
    [Required]
    public string FirstName { get; private set; }
    [Required]
    public string LastName { get; private set; }
    [Required]
    [EmailAddress]
    public string Email { get; private set; }
    [Required]
    public Guid CompanyId { get; private set; }

    public IReadOnlyList<string> Roles { get; private set; }
}