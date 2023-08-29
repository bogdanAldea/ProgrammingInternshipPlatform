using ProgrammingInternshipPlatform.Domain.Accounts.Identifiers;
using ProgrammingInternshipPlatform.Domain.InternshipHub.Internships.Enums;
using ProgrammingInternshipPlatform.Domain.InternshipHub.Internships.Identifiers;
using ProgrammingInternshipPlatform.Domain.InternshipHub.Internships.Models;
using ProgrammingInternshipPlatform.Domain.InternshipHub.Trainers.Identifiers;
using ProgrammingInternshipPlatform.Domain.InternshipHub.Trainers.Validators;

namespace ProgrammingInternshipPlatform.Domain.InternshipHub.Trainers.Models;

public class Trainer
{
    private readonly List<Internship> _internships = new();
    private readonly List<TechnologyStack> _technologyStack = new();

    public TrainerId Id { get; private set; }
    public AccountId AccountId { get; private set; }
    public IReadOnlyCollection<Internship> Internships => _internships;
    public IReadOnlyCollection<TechnologyStack> TechnologyStack => _technologyStack;

    public static async Task<Trainer> AssignMemberAsTrainer(AccountId accountId,
        IReadOnlyCollection<TechnologyStack> technologies, CancellationToken cancellationToken)
    {
        var validator = new TrainerValidator();
        var newTrainer = new Trainer
        {
            Id = new TrainerId(Guid.NewGuid()),
            AccountId = accountId
        };
        
        newTrainer._technologyStack.AddRange(technologies);
        await validator.ValidateDomainModelAsync(newTrainer, cancellationToken);
        return newTrainer;
    }
}