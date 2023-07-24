using ProgrammingInternshipPlatform.Domain.Organisation.Centers;

namespace ProgrammingInternshipPlatform.Api.Organisation.Contracts.Responses;

public class CenterResponse
{
    public Guid Id { get; private set; }
    public string Location { get; private set; } = null!;

    public static CenterResponse MapFromCenter(Center center)
    {
        return new CenterResponse
        {
            Id = center.Id.Value,
            Location = center.Location
        };
    }
}