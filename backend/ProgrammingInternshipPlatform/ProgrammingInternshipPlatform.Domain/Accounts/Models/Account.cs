using ProgrammingInternshipPlatform.Domain.Accounts.Identifiers;

namespace ProgrammingInternshipPlatform.Domain.Accounts.Models;

public class Account
{
    public AccountId Id { get; set; }
    public string DisplayName { get; set; }
    public string GivenName { get; set; }
    public string Surname { get; set; }
    public string JobTitle { get; set; }
    public string Email { get; set; }
    public List<string> Roles { get; set; }
}