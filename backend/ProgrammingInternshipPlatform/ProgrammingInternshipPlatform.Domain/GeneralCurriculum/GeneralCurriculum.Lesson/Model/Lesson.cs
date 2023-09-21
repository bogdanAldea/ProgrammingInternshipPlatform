using ProgrammingInternshipPlatform.Domain.GeneralCurriculum.Abstracts;
using ProgrammingInternshipPlatform.Domain.GeneralCurriculum.GeneralCurriculum.Chapter.Identifiers;
using ProgrammingInternshipPlatform.Domain.GeneralCurriculum.GeneralCurriculum.Lesson.Identifier;

namespace ProgrammingInternshipPlatform.Domain.GeneralCurriculum.GeneralCurriculum.Lesson.Model;

public class Lesson : IDeepCloneable<Lesson>
{
    public LessonId LessonId { get; private set; }
    public ChapterId ChapterId { get; private set; }
    public Assignment.Model.Assignment Assignment { get; private set; } = null!;
    public string Title { get; private set; } = null!;
    public string Description { get; private set; } = null!;
    public Lesson Clone()
    {
        var clone = new Lesson
        {
            LessonId = new LessonId(Guid.NewGuid()),
            ChapterId = this.ChapterId,
            Assignment = this.Assignment.Clone(),
            Title = this.Title,
            Description = this.Description
        };
        return clone;
    }
}