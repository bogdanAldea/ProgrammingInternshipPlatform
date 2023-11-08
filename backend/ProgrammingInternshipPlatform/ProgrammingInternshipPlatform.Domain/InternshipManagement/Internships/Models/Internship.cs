using ProgrammingInternshipPlatform.Domain.AccountManagement.Identifiers;
using ProgrammingInternshipPlatform.Domain.InternshipManagement.Interns.Models;
using ProgrammingInternshipPlatform.Domain.InternshipManagement.Internships.Enums;
using ProgrammingInternshipPlatform.Domain.InternshipManagement.Internships.Validators;
using ProgrammingInternshipPlatform.Domain.InternshipManagement.Mentorships.Models;
using ProgrammingInternshipPlatform.Domain.InternshipManagement.Trainers.Models;
using ProgrammingInternshipPlatform.Domain.ModuleManagement.Models;
using ProgrammingInternshipPlatform.Domain.Shared.Validators;

namespace ProgrammingInternshipPlatform.Domain.InternshipManagement.Internships.Models;

public class Internship
{
    private readonly List<Intern> _interns = new();
    private readonly List<Trainer> _trainers = new();
    private readonly List<Mentorship> _mentorships = new();
    private static readonly InternshipValidator _validator = new();

    public InternshipId InternshipId { get; private set; }
    public AccountId CoordinatorId { get; private set; }
    public DateTime ScheduledStartDate { get; private set; }
    public DateTime EstimatedGraduationDate { get; private set; }
    public InternshipStatus InternshipStatus { get; private set; }
    public int DurationInMonths { get; private set; }
    public int MaxInternsToEnroll { get; private set; }
    public IReadOnlyList<Intern> Interns => _interns;
    public IReadOnlyList<Trainer> Trainers => _trainers;
    public IReadOnlyList<Mentorship> Mentorships => _mentorships;

    public static async Task<Internship> ScheduleNewInternship(AccountId coordinatorId, DateTime scheduleStartDate,
        int durationInMonths, int maxInternsToEnroll, CancellationToken cancellationToken)
    {
        var internship = new Internship
        {
            InternshipId = new InternshipId(Guid.NewGuid()),
            CoordinatorId = coordinatorId,
            DurationInMonths = durationInMonths,
            MaxInternsToEnroll = maxInternsToEnroll,
            ScheduledStartDate = scheduleStartDate,
            EstimatedGraduationDate = scheduleStartDate.AddMonths(durationInMonths)
        };

        await _validator.ValidateDomainModelAsync(internship, rules =>
        {
            rules.IncludeRuleSets(InternshipRuleSets.General, InternshipRuleSets.Creation);
        }, cancellationToken);

        return internship;
    }
}