using ProgrammingInternshipPlatform.Domain.Organization.Center;

namespace ProgrammingInternshipPlatform.Domain.Organization.Company;

public class Company
{
    private readonly List<Location> _locations = new();
    public Company() {}

    public CompanyId Id { get; private set; }
    public string Name { get; private set; } = null!;
    public IReadOnlyCollection<Location> Locations => _locations;

}