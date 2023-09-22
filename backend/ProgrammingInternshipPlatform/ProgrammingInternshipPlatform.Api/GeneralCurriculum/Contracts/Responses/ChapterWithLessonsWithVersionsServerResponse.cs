using ProgrammingInternshipPlatform.Application.GeneralCurriculum.Contracts.Responses;
using ProgrammingInternshipPlatform.Application.Helpers.EnumRetrieval;
using ProgrammingInternshipPlatform.Domain.GeneralCurriculum.GeneralCurriculum.Chapter.Enums;
using ProgrammingInternshipPlatform.Domain.GeneralCurriculum.GeneralCurriculum.Lesson.Model;

namespace ProgrammingInternshipPlatform.Api.GeneralCurriculum.Contracts.Responses;

public class ChapterWithLessonsWithVersionsServerResponse
{
    public Guid ChapterId { get; private set; }
    public string Title { get; private set; } = null!;
    public string Description { get; init; } = null!;
    public DomainEnumConverted<ChapterType> ChapterType { get; init; } = null!;
    public IReadOnlyList<LessonServerResponse> Lessons { get; init; } = null!;
    public IReadOnlyList<CurrentVersionPartial> VersionedModules { get; private set; } = null!;
    public int Versions { get; private set; }

    public static ChapterWithLessonsWithVersionsServerResponse CreateFromResource(ChapterWithLessonsWithVersions chapter)
    {
        return new ChapterWithLessonsWithVersionsServerResponse
        {
            ChapterId = chapter.Chapter.ChapterId.Value,
            Title = chapter.Chapter.Title,
            Description = chapter.Chapter.Description,
            ChapterType = EnumRetrievalHelper.ConvertEnumValue(chapter.Chapter.ChapterType),
            Lessons = chapter.Lessons.Select(LessonServerResponse.CreateFromResource).ToList(),
            VersionedModules = chapter.VersionedModules.Select(CurrentVersionPartial.CreateFromResource).ToList(),
            Versions = chapter.Versions
        };
    }
}