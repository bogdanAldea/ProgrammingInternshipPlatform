using ProgrammingInternshipPlatform.Domain.Organisation.Company;

namespace ProgrammingInternshipPlatform.Domain.Organisation.Countries;

public class Country
{
    public CountryId CountryId { get; private set; }
    public CompanyId CompanyId { get; private set; }
    public string Name { get; private set; }
}