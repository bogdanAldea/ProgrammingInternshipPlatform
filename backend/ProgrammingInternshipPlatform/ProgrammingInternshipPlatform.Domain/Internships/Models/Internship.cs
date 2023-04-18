using ProgrammingInternshipPlatform.Domain.Internships.Enums;
using ProgrammingInternshipPlatform.Domain.Internships.Identifiers;
using ProgrammingInternshipPlatform.Domain.Locations.Identifiers;
using ProgrammingInternshipPlatform.Domain.Locations.Models;

namespace ProgrammingInternshipPlatform.Domain.Internships.Models;

public class Internship
{
    public Internship() {}
    
    public InternshipId Id { get; private set; }
    public LocationId LocationId { get; private set; }
    public InternshipStatus Status { get; private set; } = InternshipStatus.SetupInProgress;
    public Timeframe Timeframe { get; set; } = null!;
    public int MaximumInternsToEnroll { get; private set; }
    public int DurationInMonths { get; set; }
}