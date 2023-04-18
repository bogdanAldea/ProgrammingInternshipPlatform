using ProgrammingInternshipPlatform.Domain.Internships.Enums;
using ProgrammingInternshipPlatform.Domain.Internships.Identifiers;
using ProgrammingInternshipPlatform.Domain.Locations.Models;

namespace ProgrammingInternshipPlatform.Domain.Internships.Models;

public class Internship
{
    public Internship() {}
    
    public InternshipId Id { get; private set; }
    public InternshipStatus Status { get; private set; } = InternshipStatus.NotStarted;
    public Timeframe Timeframe { get; set; } = null!;
    public Location Location { get; private set; } = null!;
    public int MaximumInternsToEnroll { get; private set; }
    public int DurationInMonths { get; set; }
}