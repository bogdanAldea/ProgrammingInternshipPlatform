using ProgrammingInternshipPlatform.Domain.Internships.Identifiers;
using ProgrammingInternshipPlatform.Domain.Locations.Identifiers;

namespace ProgrammingInternshipPlatform.Domain.Locations.Models;

public class Location
{
    public Location() {}

    public LocationId Id { get; private set; }
    public string Center { get; private set; } = null!;
    public string Country { get; private set; } = null!;
}