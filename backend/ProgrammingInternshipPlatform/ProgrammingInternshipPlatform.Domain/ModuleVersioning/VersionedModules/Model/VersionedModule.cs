using ProgrammingInternshipPlatform.Domain.GeneralCurriculum.GeneralCurriculum.Chapter.Identifiers;
using ProgrammingInternshipPlatform.Domain.InternshipHub.VersionedCurriculums.Identifiers;
using ProgrammingInternshipPlatform.Domain.ModuleVersioning.VersionedModules.Identifier;

namespace ProgrammingInternshipPlatform.Domain.ModuleVersioning.VersionedModules.Model;

public class VersionedModule
{
    public VersionedModuleId VersionedModuleId { get; private set; } = new(Guid.NewGuid());
    public VersionedCurriculumId VersionedCurriculumId { get; private set; }
    public ChapterId ChapterId { get; private set; }
    public DateTime VersionedOnDate { get; private set; }
    public string VersionNumber { get; private set; } = null!;

    public static VersionedModule CreateVersionedModule(Guid chapterToVersionId, int versionedChapters)
    {
        return new VersionedModule
        {
            ChapterId = new ChapterId(chapterToVersionId),
            VersionedOnDate = DateTime.Now,
            VersionNumber = $"{DateTime.Today.Year}.{versionedChapters}"
        };
    }
}