using ProgrammingInternshipPlatform.Domain.Locations.Identifiers;

namespace ProgrammingInternshipPlatform.Domain.Locations.Models;

public class Location
{
    public Location(LocationId id, string center, string country)
    {
        Id = id;
        Center = center;
        Country = country;
    }
    public LocationId Id { get; set; }
    public string Center { get; set; }
    public string Country { get; set; }
}