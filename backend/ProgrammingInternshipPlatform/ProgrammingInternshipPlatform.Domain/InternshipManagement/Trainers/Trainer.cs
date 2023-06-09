using ProgrammingInternshipPlatform.Domain.Account.UserAccounts;
using ProgrammingInternshipPlatform.Domain.InternshipManagement.Internships;

namespace ProgrammingInternshipPlatform.Domain.InternshipManagement.Trainers;

public class Trainer
{
    private readonly List<Internship> _internships = new();
    public TrainerId Id { get; private set; }
    public AccountId AccountId { get; private set; }
    public IReadOnlyCollection<Internship> Internships => _internships;
}