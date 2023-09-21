using ProgrammingInternshipPlatform.Application.GeneralCurriculum.Contracts.Responses;
using ProgrammingInternshipPlatform.Domain.GeneralCurriculum.GeneralCurriculum.Chapter.Models;
using ProgrammingInternshipPlatform.Domain.VersionedModules.Model;

namespace ProgrammingInternshipPlatform.Api.GeneralCurriculum.Contracts.Responses;

public class ChapterWithVersionServerResponse
{
    private ChapterWithVersionServerResponse(ChapterWithVersioning chapterWithVersioning)
    {
        ChapterId = chapterWithVersioning.Chapter.ChapterId.Value;
        Title = chapterWithVersioning.Chapter.Title;
        Description = chapterWithVersioning.Chapter.Description;
        NumberOfLessons = chapterWithVersioning.Chapter.Lessons.Count;
        Versions = chapterWithVersioning.Versions;
        CurrentVersion = chapterWithVersioning.VersionedModule != null
            ? CreateCurrentVersionPartial(chapterWithVersioning.VersionedModule)
            : null;
    }
    public Guid ChapterId { get; private set; }
    public string Title { get; private set; }
    public string Description { get; private set; }
    public int NumberOfLessons { get; private set; }
    public int Versions { get; set; }
    public CurrentVersionPartial? CurrentVersion { get; set; }

    public static ChapterWithVersionServerResponse CreateFromResource(ChapterWithVersioning chapterWithVersioning)
    {
        return new ChapterWithVersionServerResponse(chapterWithVersioning);
    }

    private static CurrentVersionPartial CreateCurrentVersionPartial(VersionedModule versionedModule)
    {
        return new CurrentVersionPartial
        {
            CurrentVersionId = versionedModule.VersionedCurriculumId.Value,
            VersionNumber = versionedModule.ReleaseVersionNumber
        };
    }
}