using ProgrammingInternshipPlatform.Domain.InternshipHub.Interns.Models;
using ProgrammingInternshipPlatform.Domain.InternshipHub.Internships.Enums;
using ProgrammingInternshipPlatform.Domain.InternshipHub.Internships.Identifiers;
using ProgrammingInternshipPlatform.Domain.InternshipHub.Mentorships.Models;
using ProgrammingInternshipPlatform.Domain.InternshipHub.Trainers.Models;

namespace ProgrammingInternshipPlatform.Domain.InternshipHub.Internships.Models;

public class Internship
{
    private readonly List<Trainer> _trainers = new();
    private readonly List<Intern> _interns = new();
    private readonly List<Mentorship> _mentorships = new();
    public InternshipId Id { get; private set; }
    public InternshipStatus Status { get; private set; } = InternshipStatus.SetupInProgress;
    public Center Center { get; private set; }
    public DateTime ScheduledToStartOn { get; private set; }
    public DateTime EstimatedToEndOn { get; private set; }
    public IReadOnlyCollection<Trainer> Trainers => _trainers;
    public IReadOnlyCollection<Intern> Interns => _interns;
    public IReadOnlyCollection<Mentorship> Mentorships => _mentorships;
    public int DurationInMonths { get; private set; }
    public int MaxInternsToEnroll { get; private set; }
}