using ProgrammingInternshipPlatform.Domain.Account.Intern;
using ProgrammingInternshipPlatform.Domain.Organization.Center;
using ProgrammingInternshipPlatform.Domain.Organization.Company;

namespace ProgrammingInternshipPlatform.Domain.InternshipManagement.Internship;

public class Internship
{
    private readonly List<Mentorship.Mentorship> _mentorships = new();
    private readonly List<InternId> _internIds = new();

    public Internship()
    {
    }

    public InternshipId Id { get; private set; }
    public CompanyId CompanyId { get; private set; }
    public LocationId LocationId { get; private set; }
    public InternshipStatus Status { get; private set; } = InternshipStatus.SetupInProgress;
    public Timeframe.Timeframe Timeframe { get; private set; } = null!;
    public IReadOnlyCollection<Mentorship.Mentorship> Mentorships => _mentorships;
    public IReadOnlyCollection<InternId> InternIds => _internIds;
    public int MaximumInternsToEnroll { get; private set; }
    public int DurationInMonths { get; private set; }

    public static async Task<Internship> SetupInternship(CompanyId companyId, LocationId locationId,
        int maxInternsToEnroll,
        int durationInMonths, DateTime startDate, CancellationToken cancellationToken)
    {
        var internshipValidator = new InternshipValidator();
        var timeframe = await InternshipManagement.Timeframe.Timeframe.ScheduleNewTimeframe(startDate, durationInMonths, cancellationToken);
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
}