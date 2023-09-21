using Microsoft.EntityFrameworkCore;
using ProgrammingInternshipPlatform.Application.Abstractions.Handlers;
using ProgrammingInternshipPlatform.Application.Abstractions.Requests;
using ProgrammingInternshipPlatform.Application.GeneralCurriculum.Contracts.Responses;
using ProgrammingInternshipPlatform.Application.ResultPattern;
using ProgrammingInternshipPlatform.Dal.Context;
using ProgrammingInternshipPlatform.Domain.GeneralCurriculum.GeneralCurriculum.Chapter.Identifiers;
using ProgrammingInternshipPlatform.Domain.GeneralCurriculum.GeneralCurriculum.Chapter.Models;
using ProgrammingInternshipPlatform.Domain.VersionedModules.Model;

namespace ProgrammingInternshipPlatform.Application.GeneralCurriculum.Chapters;

public record GetAllChaptersQuery() : IApplicationCollectionRequest<ChapterWithVersioning>;

public class GetAllChaptersHandler : IApplicationCollectionHandler<GetAllChaptersQuery, ChapterWithVersioning>
{

    private readonly ProgrammingInternshipPlatformDbContext _context;

    public GetAllChaptersHandler(ProgrammingInternshipPlatformDbContext context)
    {
        _context = context;
    }
    
    public async Task<HandlerResult<IReadOnlyList<ChapterWithVersioning>>> Handle(GetAllChaptersQuery request, CancellationToken cancellationToken)
    {
        var chaptersWithVersioning = new List<ChapterWithVersioning>();
        var allChapters = await GetAllChapters(cancellationToken);
        var allVersionedChapters = await GetAllVersionedChapters(cancellationToken);

        foreach (var chapter in allChapters)
        {
            var versions = MatchChapterToVersions(allVersionedChapters, chapter.ChapterId);
            var latestVersion = GetLatestVersionedModule(versions);
            var versionedModulePartial = latestVersion != null ? CreateCurrentVersionPartial(latestVersion) : null;
            var chapterWithVersioning = CreateChapterWithVersioning(chapter, versions.Count, versionedModulePartial);
            chaptersWithVersioning.Add(chapterWithVersioning);
        }
        
        return HandlerResult<IReadOnlyList<ChapterWithVersioning>>.Success(chaptersWithVersioning);
    }
    
    private async Task<IReadOnlyList<Chapter>> GetAllChapters(CancellationToken cancellationToken) => 
        await _context.Chapter
        .Include(chapter => chapter.Lessons)
        .ToListAsync(cancellationToken);
    
    private async Task<IReadOnlyList<VersionedModule>> GetAllVersionedChapters(CancellationToken cancellationToken) => 
        await _context.VersionedModule
            .ToListAsync(cancellationToken);
    
    private IReadOnlyList<VersionedModule> MatchChapterToVersions(IReadOnlyList<VersionedModule> allVersionedChapters, 
        ChapterId chapterId) => allVersionedChapters
            .Where(version => version.ChapterId == chapterId)
            .ToList();
    
    private VersionedModule? GetLatestVersionedModule(IReadOnlyList<VersionedModule> versions) => 
        versions.MaxBy(version => version.VersionedOnDate);

    private CurrentVersionPartial? CreateCurrentVersionPartial(VersionedModule currentVersionedModule)
    {
        return new CurrentVersionPartial
        {
            CurrentVersionId = currentVersionedModule.VersionedCurriculumId.Value,
            VersionNumber = currentVersionedModule.ReleaseVersionNumber
        };
    }
    
    private ChapterWithVersioning CreateChapterWithVersioning(Chapter chapter, int numberIfVersions, CurrentVersionPartial? versionedModule) =>
        new ChapterWithVersioning
        {
            ChapterId = chapter.ChapterId.Value,
            Title = chapter.Title,
            Description = chapter.Description,
            NumberOfLessons = chapter.Lessons.Count,
            Versions = numberIfVersions,
            CurrentVersion = versionedModule
        };
}