using ProgrammingInternshipPlatform.Domain.AccountManagement.Identifiers;
using ProgrammingInternshipPlatform.Domain.InternshipManagement.Internships.Models;

namespace ProgrammingInternshipPlatform.Domain.InternshipManagement.Trainers.Models;

public class Trainer
{
    private readonly List<Internship> _internships = new();

    public TrainerId TrainerId { get; private set; }
    public AccountId AccountId { get; private set; }
    public IReadOnlyList<Internship> Internships => _internships;
}