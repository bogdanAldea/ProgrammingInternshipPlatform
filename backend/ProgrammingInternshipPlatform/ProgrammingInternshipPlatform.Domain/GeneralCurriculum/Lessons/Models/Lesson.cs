using ProgrammingInternshipPlatform.Domain.GeneralCurriculum.Abstractions;
using ProgrammingInternshipPlatform.Domain.GeneralCurriculum.Assignments.Models;
using ProgrammingInternshipPlatform.Domain.GeneralCurriculum.LearningResources.Models;
using ProgrammingInternshipPlatform.Domain.GeneralCurriculum.Lessons.Validators;
using ProgrammingInternshipPlatform.Domain.GeneralCurriculum.Topics.Identifiers;

namespace ProgrammingInternshipPlatform.Domain.GeneralCurriculum.Lessons.Models;

public class Lesson : IDeepCloneable<Lesson>
{
    private Lesson(string title, string description, int topicOrder, TopicId topicId)
    {
        Title = title;
        Description = description;
        TopicOrder = topicOrder;
        TopicId = topicId;
    }

    private Lesson(string title, string description, int topicOrder, TopicId topicId, Assignment? assignment)
    {
        Title = title;
        Description = description;
        TopicOrder = topicOrder;
        TopicId = topicId;
        Assignment = assignment;
    }

    private static LessonValidator _lessonValidator = new();
    private List<LearningResource> _learningResources = new();
    public LessonId LessonId { get; private set; } = new LessonId(Guid.NewGuid());
    public Assignment? Assignment { get; private set; }
    public IReadOnlyList<LearningResource> LearningResources { get; private set; }
    public TopicId TopicId { get; private set; }
    public string Title { get; private set; }
    public string Description { get; private set; }
    public int TopicOrder { get; private set; }

    public static async Task<Lesson> CreateNewLesson(string title, string description, int topicOrder, TopicId topicId,
        CancellationToken cancellationToken)
    {
        var newLesson = new Lesson(title: title, description: description, topicOrder: topicOrder, topicId: topicId);
        
        await _lessonValidator.ValidateDomainModelAsync(newLesson,
            ruleSets => { ruleSets.IncludeRuleSets(LessonRuleSets.General); },
            cancellationToken);
        
        return newLesson;
    }

    public static async Task<Lesson> CreateNewLesson(string title, string description, int topicOrder, TopicId topicId,
        Assignment assignment, CancellationToken cancellationToken)
    {
        var newLesson = new Lesson(title: title, description: description, topicOrder: topicOrder, topicId: topicId,
            assignment: assignment);
        
        await _lessonValidator.ValidateDomainModelAsync(newLesson,
            ruleSets => { ruleSets.IncludeRuleSets(LessonRuleSets.General, LessonRuleSets.AddAssignment); },
            cancellationToken);
        
        return newLesson;
    }

    public async Task<Lesson> Clone(CancellationToken cancellationToken)
    {
        var versionedLesson = new Lesson(title: this.Title, description: this.Description, topicOrder: this.TopicOrder,
            topicId: this.TopicId, assignment: this.Assignment);
        
        var versionedResources = await Task.WhenAll(
            _learningResources.Select(async resource => await resource.Clone(cancellationToken)));
        
        versionedResources.ToList().ForEach(resource => versionedLesson._learningResources.Add(resource));
        
        await _lessonValidator.ValidateDomainModelAsync(versionedLesson, 
            ruleSets =>
            {
                ruleSets.IncludeRuleSets(LessonRuleSets.General, LessonRuleSets.Versioning);
            },
            cancellationToken);
        
        return versionedLesson;
    }
}