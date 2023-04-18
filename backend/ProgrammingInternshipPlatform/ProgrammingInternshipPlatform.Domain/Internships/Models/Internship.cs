using ProgrammingInternshipPlatform.Domain.Internships.Enums;
using ProgrammingInternshipPlatform.Domain.Internships.Identifiers;
using ProgrammingInternshipPlatform.Domain.Internships.Validators;
using ProgrammingInternshipPlatform.Domain.Locations.Identifiers;

namespace ProgrammingInternshipPlatform.Domain.Internships.Models;

public class Internship
{
    public Internship()
    {
    }

    public InternshipId Id { get; private set; }
    public LocationId LocationId { get; private set; }
    public InternshipStatus Status { get; private set; } = InternshipStatus.SetupInProgress;
    public Timeframe Timeframe { get; set; } = null!;
    public int MaximumInternsToEnroll { get; private set; }
    public int DurationInMonths { get; set; }

    public static async Task<Internship> SetupInternship(LocationId locationId, int maxInternsToEnroll,
        int durationInMonths, DateTime startDate, DateTime endDate)
    {
        var internshipValidator = new InternshipValidator();
        var timeframe = Timeframe.ScheduleNewTimeframe(startDate, endDate);
        var internshipToValidate = new Internship()
        {
            Id = new InternshipId(Guid.NewGuid()),
            LocationId = locationId,
            Timeframe = timeframe,
            MaximumInternsToEnroll = maxInternsToEnroll,
            DurationInMonths = durationInMonths
        };

        await internshipValidator.ValidateDomainModelAsync(internshipToValidate);
        return internshipToValidate;
    }
}