using MediatR;
using ProgrammingInternshipPlatform.Dal.Context;
using ProgrammingInternshipPlatform.Dal.Queries.Modules;
using ProgrammingInternshipPlatform.Domain.GeneralCurriculumManagement.Topics.Events;
using ProgrammingInternshipPlatform.Domain.ModuleManagement.Models;

namespace ProgrammingInternshipPlatform.Application.GeneralCurriculumManagement.General.CreateVersionOfTopic;

public class SetModuleOnVersionedTopicCreated : INotificationHandler<TopicVersionedEvent>
{
    private readonly ProgrammingInternshipPlatformDbContext _context;

    public SetModuleOnVersionedTopicCreated(ProgrammingInternshipPlatformDbContext context)
    {
        _context = context;
    }

    public async Task Handle(TopicVersionedEvent notification, CancellationToken cancellationToken)
    {
        var versionedModulesForTopic = _context.CountAllModulesByVersionedTopic(notification.VersionedTopicId);

        var newModule = await Module.CreateNew(topicId: notification.VersionedTopicId,
            versionedByUser: notification.VersionedByUser, versionedTopics: versionedModulesForTopic,
            cancellationToken);

        await _context.Modules.AddAsync(newModule, cancellationToken);
    }
}