using ProgrammingInternshipPlatform.Domain.Account.UserAccounts;
using ProgrammingInternshipPlatform.Domain.InternshipManagement.Internships;

namespace ProgrammingInternshipPlatform.Domain.InternshipManagement.Interns;

public class Intern
{
    public Intern() {}
    
    public InternId Id { get; private set; }
    public AccountId AccountId { get; private set; }
    public InternshipId InternshipId { get; private set; }
}