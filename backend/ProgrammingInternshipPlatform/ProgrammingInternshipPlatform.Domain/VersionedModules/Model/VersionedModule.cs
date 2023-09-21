using ProgrammingInternshipPlatform.Domain.GeneralCurriculum.GeneralCurriculum.Chapter.Identifiers;
using ProgrammingInternshipPlatform.Domain.InternshipHub.VersionedCurriculums.Identifiers;
using ProgrammingInternshipPlatform.Domain.VersionedModules.Identifier;

namespace ProgrammingInternshipPlatform.Domain.VersionedModules.Model;

public class VersionedModule
{
    public VersionedModuleId VersionedModuleId { get; private set; } = new(Guid.NewGuid());
    public VersionedCurriculumId VersionedCurriculumId { get; private set; }
    public ChapterId ChapterId { get; private set; }
    public DateTime VersionedOnDate { get; private set; }
    public string ReleaseVersionNumber { get; private set; } = CreateVersionNumber();

    private static string CreateVersionNumber()
    {
        return $"{DateTime.Today.Year}.{DateTime.Today.Month}.{DateTime.Today.Day}";
    }
}