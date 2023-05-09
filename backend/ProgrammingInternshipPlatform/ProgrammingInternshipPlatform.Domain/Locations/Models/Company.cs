using ProgrammingInternshipPlatform.Domain.Locations.Identifiers;

namespace ProgrammingInternshipPlatform.Domain.Locations.Models;

public class Company
{
    private readonly List<Location> _locations = new();
    public Company() {}

    public CompanyId Id { get; private set; }
    public string Name { get; private set; } = null!;
    public IReadOnlyCollection<Location> Locations => _locations;

    public static Task<Company> CreateNew()
    {
        throw new NotImplementedException();
    }

    public Task AddNewLocation(Location location)
    {
        throw new NotImplementedException();
    }
}