using ProgrammingInternshipPlatform.Dal.Context;
using ProgrammingInternshipPlatform.Domain.GeneralCurriculum.GeneralCurriculum.Chapter.Identifiers;
using ProgrammingInternshipPlatform.Domain.ModuleVersioning.VersionedModules.Model;

namespace ProgrammingInternshipPlatform.Dal.VersionedModuleExtensions;

public static class VersionedModuleRetrieval
{
    public static VersionedModule? FromLatestVersion(this IQueryable<VersionedModule> queryable)
        => queryable.MaxBy(module => module.VersionedOnDate);

    public static IQueryable<VersionedModule> MatchVersionedModulesByChapter(
        this ProgrammingInternshipPlatformDbContext context, ChapterId chapterId)
        => context.VersionedModule.Where(module => module.ChapterId == chapterId);
    
    public static IReadOnlyList<VersionedModule> GetVersionedModulesOfChapterOrderedByVersionedDate(
        this ProgrammingInternshipPlatformDbContext context, ChapterId chapterId)
        => context.VersionedModule
            .Where(module => module.ChapterId == chapterId)
            .OrderByDescending(module => module.VersionedOnDate)
            .ToList();
}