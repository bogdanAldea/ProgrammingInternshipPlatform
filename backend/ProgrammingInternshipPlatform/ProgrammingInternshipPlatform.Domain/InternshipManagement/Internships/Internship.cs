using ProgrammingInternshipPlatform.Domain.InternshipManagement.Interns;
using ProgrammingInternshipPlatform.Domain.InternshipManagement.Mentorships;
using ProgrammingInternshipPlatform.Domain.InternshipManagement.Timeframes;
using ProgrammingInternshipPlatform.Domain.InternshipManagement.Trainers;
using ProgrammingInternshipPlatform.Domain.Organization.Center;
using ProgrammingInternshipPlatform.Domain.Organization.Companys;
using ProgrammingInternshipPlatform.Domain.Shared.Exceptions;

namespace ProgrammingInternshipPlatform.Domain.InternshipManagement.Internships;

public class Internship
{
    private static readonly InternshipValidator Validator = new();
    private readonly List<Mentorship> _mentorships = new();
    private readonly List<Intern> _interns = new();
    private readonly List<Trainer> _trainers = new();
    public Internship()
    {
    }

    public InternshipId Id { get; private set; }
    public CompanyId CompanyId { get; private set; }
    public LocationId LocationId { get; private set; }
    public InternshipStatus Status { get; private set; } = InternshipStatus.SetupInProgress;
    public Timeframe Timeframe { get; private set; } = null!;
    public IReadOnlyCollection<Mentorship> Mentorships => _mentorships;
    public IReadOnlyCollection<Intern> Interns => _interns;
    public IReadOnlyCollection<Trainer> Trainers => _trainers;
    public int MaximumInternsToEnroll { get; private set; }
    public int DurationInMonths { get; private set; }

    public static async Task<Internship> SetupInternship(CompanyId companyId, LocationId locationId,
        int maxInternsToEnroll,
        int durationInMonths, DateTime startDate, CancellationToken cancellationToken)
    {
        var internshipValidator = new InternshipValidator();
        var timeframe = await Timeframe.ScheduleNewTimeframe(startDate, durationInMonths, cancellationToken);
        var internshipToValidate = new Internship()
        {
            Id = new InternshipId(Guid.NewGuid()),
            CompanyId = companyId,
            LocationId = locationId,
            Timeframe = timeframe,
            MaximumInternsToEnroll = maxInternsToEnroll,
            DurationInMonths = durationInMonths
        };

        await internshipValidator.ValidateDomainModelAsync(internshipToValidate, cancellationToken);
        return internshipToValidate;
    }

    public async Task RescheduleInternshipStartDate(DateTime rescheduledStartDate, CancellationToken cancellationToken)
    {
        var internshipValidator = new InternshipValidator();
        await Timeframe.RescheduleStartDate(rescheduledStartDate, DurationInMonths, cancellationToken);
        await internshipValidator.ValidateDomainModelAsync(this, cancellationToken);
    }

    public async Task ExtendInternshipEndDate(DateTime extendedEndDate, CancellationToken cancellationToken)
    {
        var internshipValidator = new InternshipValidator();
        await Timeframe.ExtendEndDate(extendedEndDate, DurationInMonths, cancellationToken);
        await internshipValidator.ValidateDomainModelAsync(this, cancellationToken);
    }

    public async Task EnrollNewIntern(Intern intern, CancellationToken cancellationToken)
    {
        if (_interns.Count <= MaximumInternsToEnroll)
        {
            _interns.Add(intern);
            await Validator.ValidateDomainModelAsync(this, cancellationToken);
            return;
        }

        throw new MaximumNumberOfInternsReachedException();
    }
}