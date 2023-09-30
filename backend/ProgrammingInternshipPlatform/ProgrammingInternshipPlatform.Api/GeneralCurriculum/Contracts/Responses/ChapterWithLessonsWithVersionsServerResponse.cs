using ProgrammingInternshipPlatform.Application.GeneralCurriculum.Contracts.Responses;
using ProgrammingInternshipPlatform.Application.Helpers.EnumRetrieval;
using ProgrammingInternshipPlatform.Domain.GeneralCurriculum.GeneralCurriculum.Chapter.Enums;
using ProgrammingInternshipPlatform.Domain.GeneralCurriculum.GeneralCurriculum.Lesson.Model;
using ProgrammingInternshipPlatform.Domain.ModuleVersioning.VersionedModules.Model;

namespace ProgrammingInternshipPlatform.Api.GeneralCurriculum.Contracts.Responses;

public class ChapterWithLessonsWithVersionsServerResponse
{
    public Guid ChapterId { get; private set; }
    public string Title { get; private set; } = null!;
    public string Description { get; init; } = null!;
    public int Lessons { get; init; }
    public int Versions { get; private set; }
    public DomainEnumConverted<ChapterType> ChapterType { get; init; } = null!;
    public CurrentVersionPartial? LatestVersion { get; set; } = null!;

    public static ChapterWithLessonsWithVersionsServerResponse CreateFromResource(ChapterWithLessonsWithVersions chapter)
    {
        return new ChapterWithLessonsWithVersionsServerResponse
        {
            ChapterId = chapter.Chapter.ChapterId.Value,
            Title = chapter.Chapter.Title,
            Description = chapter.Chapter.Description,
            Lessons = chapter.Lessons,
            Versions = chapter.Versions,
            ChapterType = EnumRetrievalHelper.ConvertEnumValue(chapter.Chapter.ChapterType),
            LatestVersion = chapter.VersionedModule != null
                ? CreateCurrentVersionPartial(chapter.VersionedModule)
                : null
        };
    }
    
    private static CurrentVersionPartial CreateCurrentVersionPartial(VersionedModule versionedModule)
    {
        return new CurrentVersionPartial
        {
            CurrentVersionId = versionedModule.VersionedCurriculumId.Value,
            VersionNumber = versionedModule.VersionNumber
        };
    }
}