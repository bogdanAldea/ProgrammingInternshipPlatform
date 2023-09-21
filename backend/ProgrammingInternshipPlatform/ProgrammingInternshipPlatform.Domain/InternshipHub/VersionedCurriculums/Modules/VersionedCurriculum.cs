using ProgrammingInternshipPlatform.Domain.InternshipHub.Internships.Identifiers;
using ProgrammingInternshipPlatform.Domain.InternshipHub.Internships.Models;
using ProgrammingInternshipPlatform.Domain.InternshipHub.VersionedCurriculums.Identifiers;

namespace ProgrammingInternshipPlatform.Domain.InternshipHub.VersionedCurriculums.Modules;

public class VersionedCurriculum
{
    private readonly List<Internship> _internships = new();
    public VersionedCurriculumId VersionedCurriculumId { get; private set; } = new(Guid.NewGuid());
    public DateTime VersionedOnDate { get; private set; }
    public IReadOnlyCollection<Internship> Internships => _internships;
}