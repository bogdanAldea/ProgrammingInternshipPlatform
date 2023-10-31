using ProgrammingInternshipPlatform.Domain.GeneralCurriculumManagement.Lessons.Models;
using ProgrammingInternshipPlatform.Domain.GeneralCurriculumManagement.Topics.Models;

namespace ProgrammingInternshipPlatform.Application.GeneralCurriculumManagement.Responses;

public class TopicReadyForVersioningResponse
{
    private readonly List<LessonResponse> _lessons = new();
    
    public TopicReadyForVersioningResponse(Topic topic)
    {
        TopicId = topic.TopicId.Value;
        Title = topic.Title;
        Description = topic.Description;
        _lessons.AddRange(topic.Lessons
            .Select(lesson => new LessonResponse(lesson)));
    }
    public Guid TopicId { get; private set; }
    public string Title { get; private set; }
    public string Description { get; private set; }
    public IReadOnlyList<LessonResponse> Lessons => _lessons;
}

public class LessonResponse
{
    public LessonResponse(Lesson lesson)
    {
        LessonId = lesson.LessonId.Value;
        Title = lesson.Title;
    }
    public Guid LessonId { get; private set; }
    public string Title { get; set; }
    public bool IsSelected { get; set; } = true;
}