using ProgrammingInternshipPlatform.Domain.GeneralCurriculum.Abstracts;
using ProgrammingInternshipPlatform.Domain.GeneralCurriculum.GeneralCurriculum.Chapter.Identifiers;
using ProgrammingInternshipPlatform.Domain.GeneralCurriculum.GeneralCurriculum.Lesson.Identifier;
using ProgrammingInternshipPlatform.Domain.GeneralCurriculum.GeneralCurriculum.Lesson.Validators;
using ProgrammingInternshipPlatform.Domain.GeneralCurriculum.LearningResources.Models;

namespace ProgrammingInternshipPlatform.Domain.GeneralCurriculum.GeneralCurriculum.Lesson.Model;

public class Lesson : IDeepCloneable<Lesson>
{
    private readonly List<LearningResource> _learningResources = new();
    public LessonId LessonId { get; private set; }
    public ChapterId ChapterId { get; private set; }
    public Assignment.Model.Assignment Assignment { get; private set; } = null!;
    public string Title { get; private set; } = null!;
    public string Description { get; private set; } = null!;
    public string LearningObjective { get; private set; } = null!;
    public int SyllabusOrder { get; private set; }

    public IReadOnlyCollection<LearningResource> LearningResources => _learningResources;

    public static async Task<Lesson> CreateNew(ChapterId chapterId, string title, string description,
        string learningObjective, int syllabusOrder, CancellationToken cancellationToken)
    {
        var lessonValidator = new LessonValidator();
        var lesson = new Lesson
        {
            ChapterId = chapterId,
            Title = title,
            Description = description,
            LearningObjective = learningObjective,
            SyllabusOrder = syllabusOrder
        };

        await lessonValidator.ValidateDomainModelAsync(lesson, cancellationToken);
        return lesson;
    }

    public Lesson Clone()
    {
        var clone = new Lesson
        {
            LessonId = new LessonId(Guid.NewGuid()),
            ChapterId = this.ChapterId,
            /*Assignment = this.Assignment.Clone(),*/
            Title = this.Title,
            Description = this.Description,
            LearningObjective = this.LearningObjective,
            SyllabusOrder = this.SyllabusOrder
        };
        
        var clonedResources = _learningResources.Select(resource => resource.Clone()).ToList();
        clonedResources.ForEach(resource => clone._learningResources.Add(resource));
        return clone;
    }
}