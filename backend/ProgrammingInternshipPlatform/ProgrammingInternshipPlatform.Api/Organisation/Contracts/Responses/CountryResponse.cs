using ProgrammingInternshipPlatform.Domain.Organisation.Countries;

namespace ProgrammingInternshipPlatform.Api.Organisation.Contracts.Responses;

public class CountryResponse
{
    public Guid Id { get; private set; }
    public string Name { get; private set; } = null!;

    public static CountryResponse MapFromCountry(Country country)
    {
        return new CountryResponse
        {
            Id = country.CountryId.Value,
            Name = country.Name
        };
    }
}