using ProgrammingInternshipPlatform.Application.Helpers.EnumRetrieval;
using ProgrammingInternshipPlatform.Domain.GeneralCurriculumManagement.Topics.Enums;
using ProgrammingInternshipPlatform.Domain.GeneralCurriculumManagement.Topics.Models;
using ProgrammingInternshipPlatform.Domain.ModuleManagement.Models;

namespace ProgrammingInternshipPlatform.Application.GeneralCurriculumManagement.Responses;

public class TopicWithVersionsResponse
{
    public Guid TopicId { get; private set; }
    public string Title { get; private set; } = null!;
    public string Description { get; private set; } = null!;
    public int NumberOfLessons { get; private set; }
    public int Versions { get; set; }
    public Converted<VersioningState> VersioningState { get; private set; } = null!;
    public LatestModuleVersion? LatestModuleVersion { get; set; }

    public static TopicWithVersionsResponse CreateFromResource(Topic topic, Module? module, int versionCount)
    {
        var latestVersion = module is not null ? LatestModuleVersion.CreateFromVersionedModule(module) : null;
        var versionedTopic = CreateFromTopic(topic, latestVersion);
        return versionedTopic;
    }

    private static TopicWithVersionsResponse CreateFromTopic(Topic topic, LatestModuleVersion? latestModuleVersion)
        => new()
        {
            TopicId = topic.TopicId.Value,
            Title = topic.Title,
            Description = topic.Description,
            NumberOfLessons = topic.Lessons.Count,
            VersioningState = EnumRetrievalHelper.ConvertEnumValue(topic.VersioningState),
            LatestModuleVersion = latestModuleVersion ?? null
        };
}