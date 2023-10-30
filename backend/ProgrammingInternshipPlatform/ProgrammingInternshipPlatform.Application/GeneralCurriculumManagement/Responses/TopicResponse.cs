using ProgrammingInternshipPlatform.Domain.GeneralCurriculumManagement.Topics.Models;

namespace ProgrammingInternshipPlatform.Application.GeneralCurriculumManagement.Responses;

public class TopicResponse
{
    public Guid TopicId { get; private set; }
    public string Title { get; private set; } = null!;
    public string Description { get; private set; } = null!;
    
    public static TopicResponse CreateFromTopic(Topic topic)
    {
        return new TopicResponse
        {
            TopicId = topic.TopicId.Value,
            Title = topic.Title,
            Description = topic.Description,
        };
    }
}