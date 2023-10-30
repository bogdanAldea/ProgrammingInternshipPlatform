using ProgrammingInternshipPlatform.Domain.AccountManagement.Identifiers;
using ProgrammingInternshipPlatform.Domain.GeneralCurriculumManagement.Topics.Models;
using ProgrammingInternshipPlatform.Domain.ModuleManagement.Validators;

namespace ProgrammingInternshipPlatform.Domain.ModuleManagement.Models;

public class Module
{
    public Module()
    {
        
    }
    public Module(TopicId topicId, AccountId versionedByUser, int versionedTopics)
    {
        TopicId = topicId;
        VersionedByUser = versionedByUser;
        VersionNumber = $"{DateTime.Today.Year}.{versionedTopics}";
    }

    private static readonly ModuleValidator _moduleValidator = new();

    public ModuleId ModuleId { get; } = new(Guid.NewGuid());
    public TopicId TopicId { get; }
    public AccountId VersionedByUser { get; }
    public DateTime VersionedOnDate { get; } = DateTime.Now;
    public string VersionNumber { get; } = null!;

    public static async Task<Module> CreateNew(TopicId topicId, AccountId versionedByUser, int versionedTopics,
        CancellationToken cancellationToken)
    {
        var module = new Module(topicId: topicId, versionedByUser: versionedByUser, versionedTopics: versionedTopics);
        await _moduleValidator.ValidateDomainModelAsync(module, cancellationToken);
        return module;
    }
}