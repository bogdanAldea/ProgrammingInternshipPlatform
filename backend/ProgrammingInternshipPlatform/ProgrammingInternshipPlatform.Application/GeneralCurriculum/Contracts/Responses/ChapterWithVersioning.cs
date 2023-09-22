
using ProgrammingInternshipPlatform.Domain.GeneralCurriculum.GeneralCurriculum.Chapter.Models;
using ProgrammingInternshipPlatform.Domain.GeneralCurriculum.GeneralCurriculum.Lesson.Model;
using VersionedModule = ProgrammingInternshipPlatform.Domain.ModuleVersioning.VersionedModules.Model.VersionedModule;

namespace ProgrammingInternshipPlatform.Application.GeneralCurriculum.Contracts.Responses;

public class ChapterWithVersioning
{
    public Chapter Chapter { get; init; } = null!;
    public VersionedModule? VersionedModule { get; init; }
    public int Versions { get; init; }

}

public class ChapterWithLessonsWithVersions
{
    public Chapter Chapter { get; set; } = null!;
    public IReadOnlyList<Lesson> Lessons { get; set; } = null!;
    public IReadOnlyList<VersionedModule> VersionedModules { get; set; } = null!;
    public int Versions { get; set; }
}