using ProgrammingInternshipPlatform.Domain.Accounts.Identifiers;
using ProgrammingInternshipPlatform.Domain.InternshipHub.Interns.Models;
using ProgrammingInternshipPlatform.Domain.InternshipHub.Internships.Enums;
using ProgrammingInternshipPlatform.Domain.InternshipHub.Internships.Identifiers;
using ProgrammingInternshipPlatform.Domain.InternshipHub.Internships.Validators;
using ProgrammingInternshipPlatform.Domain.InternshipHub.Mentorships.Models;
using ProgrammingInternshipPlatform.Domain.InternshipHub.Trainers.Models;
using ProgrammingInternshipPlatform.Domain.Shared.ErrorHandling.Exceptions;

namespace ProgrammingInternshipPlatform.Domain.InternshipHub.Internships.Models;

public class Internship
{
    private readonly List<Trainer> _trainers = new();
    private readonly List<Intern> _interns = new();
    private readonly List<Mentorship> _mentorships = new();
    public InternshipId Id { get; private set; } = new(Guid.NewGuid());
    public AccountId CoordinatorId { get; private set; }
    public InternshipStatus Status { get; private set; } = InternshipStatus.SetupInProgress;
    public Center Center { get; private set; }
    public DateTime ScheduledToStartOn { get; private set; }
    public DateTime EstimatedToEndOn { get; private set; }
    public IReadOnlyCollection<Trainer> Trainers => _trainers;
    public IReadOnlyCollection<Intern> Interns => _interns;
    public IReadOnlyCollection<Mentorship> Mentorships => _mentorships;
    public int DurationInMonths { get; private set; }
    public int MaxInternsToEnroll { get; private set; }

    public static async Task<Internship> CreateInternshipSetup(Center center, Guid coordinatorId, int durationInMonths,
        int maxInternsToEnroll, DateTime scheduledToStartOn, DateTime? estimatedToEndOn, CancellationToken cancellationToken)
    {
        var internshipSetupValidator = new InternshipSetupValidator();
        var internshipSetup = new Internship
        {
            Center = center,
            CoordinatorId = new AccountId(coordinatorId),
            DurationInMonths = durationInMonths,
            MaxInternsToEnroll = maxInternsToEnroll,
            ScheduledToStartOn = scheduledToStartOn,
            EstimatedToEndOn = estimatedToEndOn ?? scheduledToStartOn.AddMonths(durationInMonths)
        };
        await internshipSetupValidator.ValidateDomainModelAsync(internshipSetup, cancellationToken);
        return internshipSetup;
    }

    public Task DelegateTrainer(Trainer trainer)
    {
        var isTrainerAlreadyDelegated =
            _trainers.Any(delegatedTrainer => delegatedTrainer.Id.Value == trainer.Id.Value);

        if (isTrainerAlreadyDelegated)
        {
            var errorMessage = "This trainer is already delegated to current internship.";
            throw new DomainModelValidationException(errorMessage);
        }
        _trainers.Add(trainer);
        return Task.CompletedTask;
    }
}