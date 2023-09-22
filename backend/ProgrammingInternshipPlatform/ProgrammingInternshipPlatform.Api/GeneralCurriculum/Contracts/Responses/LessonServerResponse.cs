using ProgrammingInternshipPlatform.Domain.GeneralCurriculum.GeneralCurriculum.Lesson.Model;

namespace ProgrammingInternshipPlatform.Api.GeneralCurriculum.Contracts.Responses;

public class LessonServerResponse
{
    public Guid LessonId { get; private set; }
    public string Title { get; private set; } = null!;
    public string Description { get; private set; } = null!;
    public string LearningObjective { get; private set; } = null!;
    public int SyllabusOrder { get; private set; }

    public static LessonServerResponse CreateFromResource(Lesson lesson)
    {
        return new LessonServerResponse
        {
            LessonId = lesson.LessonId.Value,
            Title = lesson.Title,
            Description = lesson.Description,
            LearningObjective = lesson.LearningObjective,
            SyllabusOrder = lesson.SyllabusOrder
        };
    }
}