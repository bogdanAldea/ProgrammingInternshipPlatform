using Microsoft.AspNetCore.Identity;
using ProgrammingInternshipPlatform.Domain.Account.Identifiers;

namespace ProgrammingInternshipPlatform.Domain.Account.Models;

public class UserAccount : IdentityUser<AccountId>
{
    public AccountId Id { get; private set; }
    public string FirstName { get; private set; } = null!;
    public string LastName { get; private set; } = null!;
    public DateTime JoiningDate { get; private set; }
}