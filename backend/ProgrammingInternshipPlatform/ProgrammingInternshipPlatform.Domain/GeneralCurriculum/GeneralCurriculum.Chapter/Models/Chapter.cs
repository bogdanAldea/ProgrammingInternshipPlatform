using ProgrammingInternshipPlatform.Domain.GeneralCurriculum.Abstracts;
using ProgrammingInternshipPlatform.Domain.GeneralCurriculum.GeneralCurriculum.Chapter.Identifiers;
using ProgrammingInternshipPlatform.Domain.GeneralCurriculum.GeneralCurriculum.Chapter.Validators;
using ProgrammingInternshipPlatform.Domain.GeneralCurriculum.ValidationConstants;
using ProgrammingInternshipPlatform.Domain.Shared.ErrorHandling.Exceptions;

namespace ProgrammingInternshipPlatform.Domain.GeneralCurriculum.GeneralCurriculum.Chapter.Models;

public class Chapter : IDeepCloneable<Chapter>
{
    private readonly List<Lesson.Model.Lesson> _lessons = new();

    public ChapterId ChapterId { get; private set; } = new(Guid.NewGuid());
    public string Title { get; private set; } = null!;
    public string Description { get; private set; } = null!;
    public IReadOnlyList<Lesson.Model.Lesson> Lessons => _lessons;

    public static async Task<Chapter> CreateNew(string title, string description, CancellationToken cancellationToken)
    {
        var chapter = new Chapter { Title = title, Description = description };
        await new ChapterValidator().ValidateDomainModelAsync(chapter, cancellationToken);
        return chapter;
    }

    public async Task AddLesson(Lesson.Model.Lesson newLesson, CancellationToken cancellationToken)
    {
        var lessonAlreadyExistsWithSameTitle = _lessons.Any(lesson => lesson.Title == newLesson.Title);
        
        if (lessonAlreadyExistsWithSameTitle)
            throw new DomainModelValidationException(ChapterDomainFailureMessages.LessonWithSameNameExists);
        _lessons.Add(newLesson);
        
        await new ChapterValidator().ValidateDomainModelAsync(this, cancellationToken);
    }

    public Chapter Clone()
    {
        var clone =  new Chapter
        {
            ChapterId = new ChapterId(Guid.NewGuid()),
            Title = this.Title,
            Description = this.Description,
        };
        
        _lessons.ToList().ForEach(lesson => clone._lessons.Add(lesson.Clone()));
        return clone;
    }
}