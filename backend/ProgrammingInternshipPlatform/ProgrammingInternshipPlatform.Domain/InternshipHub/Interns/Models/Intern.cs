using ProgrammingInternshipPlatform.Domain.InternshipHub.Interns.Identifiers;
using ProgrammingInternshipPlatform.Domain.InternshipHub.Internships.Identifiers;

namespace ProgrammingInternshipPlatform.Domain.InternshipHub.Interns.Models;

public class Intern
{
    public InternId InternId { get; private set; }
    public InternshipId InternshipId { get; private set; }
}