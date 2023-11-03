using ProgrammingInternshipPlatform.Domain.AccountManagement.Identifiers;
using ProgrammingInternshipPlatform.Domain.InternshipManagement.Internships.Models;

namespace ProgrammingInternshipPlatform.Domain.InternshipManagement.Interns.Models;

public class Intern
{
    public InternId InternId { get; private set; }
    public AccountId AccountId { get; private set; }
    public InternshipId InternshipId { get; private set; }
}