using ProgrammingInternshipPlatform.Domain.Shared.Identifiers;

namespace ProgrammingInternshipPlatform.Domain.Locations.Identifiers;

public class LocationId : BaseIdentifier
{
    protected LocationId(Guid value) : base(value) {}
}