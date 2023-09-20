using ProgrammingInternshipPlatform.Domain.Accounts.Identifiers;
using ProgrammingInternshipPlatform.Domain.InternshipHub.Internships.Identifiers;
using ProgrammingInternshipPlatform.Domain.InternshipHub.Internships.Models;
using ProgrammingInternshipPlatform.Domain.InternshipHub.Trainers.Identifiers;

namespace ProgrammingInternshipPlatform.Domain.InternshipHub.Trainers.Models;

public class Trainer
{
    private readonly List<Internship> _internships = new();
    
    public TrainerId Id { get; private set; }
    public AccountId AccountId { get; private set; }
    public IReadOnlyCollection<Internship> Internships => _internships;
}