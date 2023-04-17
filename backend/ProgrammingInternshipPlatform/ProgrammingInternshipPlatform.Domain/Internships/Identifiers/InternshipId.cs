using ProgrammingInternshipPlatform.Domain.Shared.Identifiers;

namespace ProgrammingInternshipPlatform.Domain.Internships.Identifiers;

public class InternshipId : BaseIdentifier
{
    public InternshipId(Guid value) : base(value) {}
}