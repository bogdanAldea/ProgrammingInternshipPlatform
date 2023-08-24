using ProgrammingInternshipPlatform.Domain.InternshipHub.Internships.Enums;
using ProgrammingInternshipPlatform.Domain.InternshipHub.Internships.Identifiers;
using ProgrammingInternshipPlatform.Domain.InternshipHub.Internships.Models;
using ProgrammingInternshipPlatform.Domain.InternshipHub.Trainers.Identifiers;

namespace ProgrammingInternshipPlatform.Domain.InternshipHub.Trainers.Models;

public class Trainer
{
    private readonly List<Internship> _internships = new();
    private readonly List<TechnologyStack> _technologyStack = new();

    public TrainerId Id { get; private set; }
    public IReadOnlyCollection<Internship> Internships => _internships;
    public IReadOnlyCollection<TechnologyStack> TechnologyStack => _technologyStack;
}