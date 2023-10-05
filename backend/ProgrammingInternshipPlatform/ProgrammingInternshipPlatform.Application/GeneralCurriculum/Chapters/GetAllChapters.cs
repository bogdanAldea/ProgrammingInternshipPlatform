using Microsoft.EntityFrameworkCore;
using ProgrammingInternshipPlatform.Application.Abstractions.Handlers;
using ProgrammingInternshipPlatform.Application.Abstractions.Requests;
using ProgrammingInternshipPlatform.Application.GeneralCurriculum.Contracts.Responses;
using ProgrammingInternshipPlatform.Application.ResultPattern;
using ProgrammingInternshipPlatform.Dal.Context;
using ProgrammingInternshipPlatform.Dal.GeneralCurriculum;
using ProgrammingInternshipPlatform.Dal.VersionedModuleExtensions;
using ProgrammingInternshipPlatform.Domain.GeneralCurriculum.GeneralCurriculum.Chapter.Enums;
using ProgrammingInternshipPlatform.Domain.GeneralCurriculum.GeneralCurriculum.Chapter.Identifiers;
using ProgrammingInternshipPlatform.Domain.GeneralCurriculum.GeneralCurriculum.Chapter.Models;
using ProgrammingInternshipPlatform.Domain.ModuleVersioning.VersionedModules.Model;

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
            var versions = MatchChapterToVersions(chapter.ChapterId);
            var latestVersion = GetLatestVersionedModule(versions);
            var chapterWithVersioning = CreateChapterWithVersioning(chapter, versions.Count, latestVersion);
            chaptersWithVersioning.Add(chapterWithVersioning);
        }
        
        return HandlerResult<IReadOnlyList<ChapterWithVersioning>>.Success(chaptersWithVersioning);
    }

    private async Task<IReadOnlyList<Chapter>> GetAllChapters(CancellationToken cancellationToken) =>
        await _context.GetOrdererUnversionedChaptersWithLessons(cancellationToken);

    private async Task<IReadOnlyList<VersionedModule>> GetAllVersionedChapters(CancellationToken cancellationToken) => 
        await _context.VersionedModule
            .ToListAsync(cancellationToken);

    private IReadOnlyList<VersionedModule> MatchChapterToVersions(ChapterId chapterId) 
        => _context
        .MatchVersionedModulesByChapter(chapterId)
        .ToList();
    
    private VersionedModule? GetLatestVersionedModule(IReadOnlyList<VersionedModule> versions) => 
        versions.MaxBy(version => version.VersionedOnDate);

    private ChapterWithVersioning CreateChapterWithVersioning(Chapter chapter, int numberIfVersions, 
        VersionedModule? versionedModule) => new ChapterWithVersioning
        {
            Chapter = chapter,
            VersionedModule = versionedModule,
            Versions = numberIfVersions
        };
}