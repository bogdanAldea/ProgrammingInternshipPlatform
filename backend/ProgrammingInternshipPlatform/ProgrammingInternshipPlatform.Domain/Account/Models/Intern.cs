using Microsoft.AspNetCore.Identity;
using ProgrammingInternshipPlatform.Domain.Account.Identifiers;
using ProgrammingInternshipPlatform.Domain.InternshipManagement.Identifiers;

namespace ProgrammingInternshipPlatform.Domain.Account.Models;

public class Intern
{
    public Intern() {}
    
    public InternId Id { get; private set; }
    public AccountId AccountId { get; private set; }
    public InternshipId InternshipId { get; private set; }
    public UserAccount Account { get; set; } = null!;
}