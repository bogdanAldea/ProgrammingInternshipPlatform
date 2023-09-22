using ProgrammingInternshipPlatform.Domain.GeneralCurriculum.Abstracts;
using ProgrammingInternshipPlatform.Domain.GeneralCurriculum.GeneralCurriculum.Chapter.Enums;
using ProgrammingInternshipPlatform.Domain.GeneralCurriculum.GeneralCurriculum.Chapter.Identifiers;
using ProgrammingInternshipPlatform.Domain.GeneralCurriculum.GeneralCurriculum.Chapter.Validators;
using ProgrammingInternshipPlatform.Domain.GeneralCurriculum.ValidationConstants;
using ProgrammingInternshipPlatform.Domain.Shared.ErrorHandling.Exceptions;

namespace ProgrammingInternshipPlatform.Domain.GeneralCurriculum.GeneralCurriculum.Chapter.Models;

public class Chapter : IDeepCloneable<Chapter>
{
    private readonly List<Lesson.Model.Lesson> _lessons = new();

    public ChapterId ChapterId { get; private set; } = new(Guid.NewGuid());
    public ChapterType ChapterType { get; private set; } = ChapterType.NotVersioned;
    public VersioningState VersioningState { get; private set; } = VersioningState.NotReadyForVersioning;
    public string Title { get; private set; } = null!;
    public string Description { get; private set; } = null!;
    public int SyllabusOrder { get; private set; }
    public IReadOnlyList<Lesson.Model.Lesson> Lessons => _lessons;

    public static async Task<Chapter> CreateNew(string title, string description, int syllabusOrder, CancellationToken cancellationToken)
    {
        var chapter = new Chapter { Title = title, Description = description, SyllabusOrder = syllabusOrder};
        await new ChapterValidator().ValidateDomainModelAsync(chapter, cancellationToken);
        return chapter;
    }

    public async Task<Chapter> CreateVersionOfChapter(CancellationToken cancellationToken)
    {
        var chapterValidator = new ChapterValidator();
        var versionedChapter = Clone();
        await chapterValidator.ValidateDomainModelAsync(versionedChapter, cancellationToken);
        return versionedChapter;
    }

    public async Task AddLesson(Lesson.Model.Lesson newLesson, CancellationToken cancellationToken)
    {
        var lessonAlreadyExistsWithSameTitle = _lessons.Any(lesson => lesson.Title == newLesson.Title);
        
        if (lessonAlreadyExistsWithSameTitle)
            throw new DomainModelValidationException(ChapterDomainFailureMessages.LessonWithSameNameExists);
        AddNewLesson(newLesson);
        
        await new ChapterValidator().ValidateDomainModelAsync(this, cancellationToken);
    }

    public Chapter Clone()
    {
        var clone =  new Chapter
        {
            ChapterId = new ChapterId(Guid.NewGuid()),
            Title = this.Title,
            ChapterType = ChapterType.Versioned,
            Description = this.Description,
            SyllabusOrder = this.SyllabusOrder
        };
        
        clone._lessons.Clear();
        var clonedLessons = _lessons.Select(lesson => lesson.Clone()).ToList();
        clonedLessons.ForEach(lesson => clone._lessons.Add(lesson));
        return clone;
    }

    private void AddNewLesson(Lesson.Model.Lesson newLesson) => _lessons.Add(newLesson);
}