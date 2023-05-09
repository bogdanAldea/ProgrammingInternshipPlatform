using Microsoft.AspNetCore.Identity;
using ProgrammingInternshipPlatform.Domain.Account.Identifiers;
using ProgrammingInternshipPlatform.Domain.Locations.Identifiers;

namespace ProgrammingInternshipPlatform.Domain.Account.Models;

public class UserAccount
{
    public AccountId Id { get; private set; }
    public Guid IdentityId { get; private set; }
    public CompanyId CompanyId { get; private set; }
    public string FirstName { get; private set; } = null!;
    public string LastName { get; private set; } = null!;
    public string? PictureUrl { get; private set; }
    public DateTime JoiningDate { get; private set; }
}