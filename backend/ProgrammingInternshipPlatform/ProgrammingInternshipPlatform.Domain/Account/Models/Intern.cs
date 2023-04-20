using Microsoft.AspNetCore.Identity;
using ProgrammingInternshipPlatform.Domain.Account.Identifiers;

namespace ProgrammingInternshipPlatform.Domain.Account.Models;

public class Intern
{
    public Intern() {}
    
    public InternId Id { get; private set; }
    public AccountId AccountId { get; private set; }
    public UserAccount Account { get; set; } = null!;
}