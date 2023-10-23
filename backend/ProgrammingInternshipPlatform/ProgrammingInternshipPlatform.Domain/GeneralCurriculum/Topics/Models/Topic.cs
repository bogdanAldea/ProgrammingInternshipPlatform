using FluentValidation;
using ProgrammingInternshipPlatform.Domain.GeneralCurriculum.Abstractions;
using ProgrammingInternshipPlatform.Domain.GeneralCurriculum.Lessons.Models;
using ProgrammingInternshipPlatform.Domain.GeneralCurriculum.Topics.Enums;
using ProgrammingInternshipPlatform.Domain.GeneralCurriculum.Topics.Identifiers;
using ProgrammingInternshipPlatform.Domain.GeneralCurriculum.Topics.Validators;

namespace ProgrammingInternshipPlatform.Domain.GeneralCurriculum.Topics.Models;

public class Topic : IDeepCloneable<Topic>
{
    private Topic(string title, string description, int syllabusOrder)
    {
        Title = title;
        Description = description;
        SyllabusOrder = syllabusOrder;
    }

    private Topic(string title, string description, int syllabusOrder, TopicType topicType)
    {
        Title = title;
        Description = description;
        SyllabusOrder = syllabusOrder;
        TopicType = topicType;
    }

    private static readonly TopicValidator _topicValidator = new();
    private readonly List<Lesson> _lessons = new();

    public TopicId TopicId { get; private set; } = new TopicId(Guid.NewGuid());
    public TopicType TopicType { get; private set; } = TopicType.NotVersioned;
    public VersioningState VersioningState { get; private set; } = VersioningState.NotReadyForVersioning;
    public IReadOnlyList<Lesson> Lessons => _lessons;
    public string Title { get; private set; }
    public string Description { get; private set; }
    public int SyllabusOrder { get; private set; }

    public static async Task<Topic> CreateUnversionedTopic(string title, string description, int syllabusOrder,
        CancellationToken cancellationToken)
    {
        var newUnversionedChapter = new Topic(title: title, description: description, syllabusOrder: syllabusOrder);
        await _topicValidator.ValidateDomainModelAsync(newUnversionedChapter,
            ruleSets =>
            {
                ruleSets.IncludeRuleSets(
                    TopicRuleSets.General,
                    TopicRuleSets.States
                );
            },
            cancellationToken);

        return newUnversionedChapter;
    }

    public async Task AddLesson(Lesson lesson, CancellationToken cancellationToken)
    {
        _lessons.Add(lesson);
        if (lesson.Assignment != null)
        {
            VersioningState = VersioningState.ReadyForVersioning;
        }

        await _topicValidator.ValidateDomainModelAsync(this, rules =>
            {
                rules.IncludeRuleSets(
                    TopicRuleSets.General,
                    TopicRuleSets.States,
                    TopicRuleSets.LessonAdd,
                    TopicRuleSets.TopicUnversioned);
            },
            cancellationToken);
    }

    public async Task RemovedLesson(Lesson lesson, CancellationToken cancellationToken)
    {
        _lessons.Remove(lesson);
        await _topicValidator.ValidateDomainModelAsync(this, ruleSets =>
            {
                ruleSets.IncludeRuleSets(
                    TopicRuleSets.General,
                    TopicRuleSets.States,
                    TopicRuleSets.LessonRemove,
                    TopicRuleSets.TopicUnversioned);
            },
            cancellationToken);
    }

    public async Task ChangeGeneralTopicDetails(string title, string description, CancellationToken cancellationToken)
    {
        Title = title;
        Description = description;
        await _topicValidator.ValidateDomainModelAsync(this, ruleSets =>
            {
                ruleSets.IncludeRuleSets(
                    TopicRuleSets.General,
                    TopicRuleSets.TopicUnversioned);
            },
            cancellationToken);
    }

    public async Task ChangeSyllabusOrder(int syllabus, CancellationToken cancellationToken)
    {
        SyllabusOrder = syllabus;
        await _topicValidator.ValidateDomainModelAsync(this, ruleSets =>
            {
                ruleSets.IncludeRuleSets(
                    TopicRuleSets.General,
                    TopicRuleSets.States,
                    TopicRuleSets.TopicUnversioned);
            },
            cancellationToken);
    }

    public async Task<Topic> Clone(CancellationToken cancellationToken)
    {
        var versionedTopic = new Topic(title: this.Title, description: this.Description,
            syllabusOrder: this.SyllabusOrder, topicType: TopicType.Versioned);

        var versionedLessons = await Task.WhenAll(_lessons.Select(async lesson => await lesson.Clone(cancellationToken)));
        versionedLessons.ToList().ForEach(lesson => versionedTopic._lessons.Add(lesson));
        
        await _topicValidator.ValidateDomainModelAsync(versionedTopic, ruleSets =>
        {
            ruleSets.IncludeRuleSets(TopicRuleSets.General, TopicRuleSets.States, TopicRuleSets.Versioning);
        }, cancellationToken);
        
        return versionedTopic;
    }
}