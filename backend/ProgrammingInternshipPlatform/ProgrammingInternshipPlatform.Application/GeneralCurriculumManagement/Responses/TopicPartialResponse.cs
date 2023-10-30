using System.ComponentModel;
using ProgrammingInternshipPlatform.Application.Helpers.EnumRetrieval;
using ProgrammingInternshipPlatform.Domain.GeneralCurriculumManagement.Topics.Enums;
using ProgrammingInternshipPlatform.Domain.GeneralCurriculumManagement.Topics.Models;

namespace ProgrammingInternshipPlatform.Application.GeneralCurriculumManagement.Responses;

public class TopicPartialResponse
{
    public Guid TopicId { get; private set; }
    public string Title { get; private set; } = null!;
    public string Description { get; private set; } = null!;
    public int SyllabusOrder { get; private set; }
    public Converted<TopicType> TopicType { get; private set; } = null!;

    public static TopicPartialResponse CreateFromTopic(Topic topic)
    {
        return new TopicPartialResponse
        {
            TopicId = topic.TopicId.Value,
            Title = topic.Title,
            Description = topic.Description,
            SyllabusOrder = topic.SyllabusOrder,
            TopicType = EnumRetrievalHelper.ConvertEnumValue(topic.TopicType)
        };
    }
}