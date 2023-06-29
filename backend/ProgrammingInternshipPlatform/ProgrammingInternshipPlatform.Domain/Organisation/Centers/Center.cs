using ProgrammingInternshipPlatform.Domain.Organisation.Countries;

namespace ProgrammingInternshipPlatform.Domain.Organisation.Centers;

public class Center
{
    public Center() {}

    public CenterId Id { get; private set; }
    public CountryId CountryId { get; private set; }
    public string Location { get; private set; }
}