using System.Collections.Immutable;
using ProgrammingInternshipPlatform.Dal.Context;
using ProgrammingInternshipPlatform.Domain.GeneralCurriculumManagement.Topics.Models;
using ProgrammingInternshipPlatform.Domain.ModuleManagement.Models;

namespace ProgrammingInternshipPlatform.Dal.Queries.Modules;

public static class ModuleRetrieval
{
    public static int CountAllModulesByVersionedTopic(this ProgrammingInternshipPlatformDbContext context, TopicId versionedTopicId)
        => context.Modules
            .Count(module => module.TopicId == versionedTopicId);

    public static IReadOnlyList<Module> GetAllModules(this ProgrammingInternshipPlatformDbContext context)
        => context.Modules.ToImmutableList();

    public static IReadOnlyList<Module> GetModulesForTopic(this ProgrammingInternshipPlatformDbContext context,
        TopicId topicId)
        => context.Modules
            .Where(module => module.TopicId == topicId)
            .ToImmutableList();
}