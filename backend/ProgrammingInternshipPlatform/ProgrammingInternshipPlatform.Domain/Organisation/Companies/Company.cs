
using ProgrammingInternshipPlatform.Domain.Organisation.Countries;

namespace ProgrammingInternshipPlatform.Domain.Organisation.Company;

public class Company
{
    private readonly List<Country> _countries = new();
    public Company() {}

    public CompanyId Id { get; private set; }
    public string Name { get; private set; } = null!;
    public IReadOnlyCollection<Country> Countries => _countries;

}