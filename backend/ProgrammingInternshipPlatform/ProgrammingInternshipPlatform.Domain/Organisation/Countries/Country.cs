using ProgrammingInternshipPlatform.Domain.Organisation.Centers;
using ProgrammingInternshipPlatform.Domain.Organisation.Companies;

namespace ProgrammingInternshipPlatform.Domain.Organisation.Countries;

public class Country
{
    public CountryId CountryId { get; private set; }
    public CompanyId CompanyId { get; private set; }
    public string Name { get; private set; }
    public List<Center> Centers { get; set; }
}