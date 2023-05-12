using ProgrammingInternshipPlatform.Domain.Organization.Company;

namespace ProgrammingInternshipPlatform.Domain.Organization.Center;

public class Location
{
    public Location() {}

    public LocationId Id { get; private set; }
    public CompanyId CompanyId { get; private set; }
    public string Center { get; private set; } = null!;
    public string Country { get; private set; } = null!;
}