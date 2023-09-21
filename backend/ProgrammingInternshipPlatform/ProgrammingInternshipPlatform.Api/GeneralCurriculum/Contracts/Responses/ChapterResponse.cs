using ProgrammingInternshipPlatform.Domain.GeneralCurriculum.GeneralCurriculum.Chapter.Models;

namespace ProgrammingInternshipPlatform.Api.GeneralCurriculum.Contracts.Responses;

public class ChapterResponse
{
    private ChapterResponse(Guid chapterId, string title, string description, int numberOfLessons)
    {
        ChapterId = chapterId;
        Title = title;
        Description = description;
        NumberOfLessons = numberOfLessons;
    }
    public Guid ChapterId { get; private set; }
    public string Title { get; private set; }
    public string Description { get; private set; }
    public int NumberOfLessons { get; private set; }

    public static ChapterResponse CreateFromResource(Chapter chapter)
    {
        return new ChapterResponse(chapter.ChapterId.Value, chapter.Title, chapter.Description, chapter.Lessons.Count);
    }
}