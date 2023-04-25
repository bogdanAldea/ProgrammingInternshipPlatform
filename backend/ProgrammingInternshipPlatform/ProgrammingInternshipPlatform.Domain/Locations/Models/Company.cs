using ProgrammingInternshipPlatform.Domain.Locations.Identifiers;

namespace ProgrammingInternshipPlatform.Domain.Locations.Models;

public class Company
{
    public Company() {}

    public CompanyId Id { get; private set; } = null!;
    public Location Location { get; private set; } = null!;
    public string Name { get; private set; } = null!;
}