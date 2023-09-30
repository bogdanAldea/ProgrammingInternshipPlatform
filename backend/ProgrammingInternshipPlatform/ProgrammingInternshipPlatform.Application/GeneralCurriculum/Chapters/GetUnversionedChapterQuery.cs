using Microsoft.EntityFrameworkCore;
using ProgrammingInternshipPlatform.Application.Abstractions.Handlers;
using ProgrammingInternshipPlatform.Application.Abstractions.Requests;
using ProgrammingInternshipPlatform.Application.GeneralCurriculum.Contracts.Responses;
using ProgrammingInternshipPlatform.Application.ResultPattern;
using ProgrammingInternshipPlatform.Dal.Context;
using ProgrammingInternshipPlatform.Domain.GeneralCurriculum.GeneralCurriculum.Chapter.Enums;
using ProgrammingInternshipPlatform.Domain.GeneralCurriculum.GeneralCurriculum.Chapter.Identifiers;
using ProgrammingInternshipPlatform.Domain.ModuleVersioning.VersionedModules.Model;

namespace ProgrammingInternshipPlatform.Application.GeneralCurriculum.Chapters;

public record GetUnversionedChapterQuery(ChapterId ChapterId) : IApplicationRequest<ChapterWithLessonsWithVersions>;

public class GetUnversionedChapterHandler 
    : IApplicationHandler<GetUnversionedChapterQuery, ChapterWithLessonsWithVersions>
{
    private readonly ProgrammingInternshipPlatformDbContext _context;

    public GetUnversionedChapterHandler(ProgrammingInternshipPlatformDbContext context)
    {
        _context = context;
    }
    
    public async Task<HandlerResult<ChapterWithLessonsWithVersions>> Handle(GetUnversionedChapterQuery request, 
        CancellationToken cancellationToken)
    {
        var unversionedChapter = await _context.Chapter
            .Include(chapter => chapter.Lessons)
            .Where(chapter => chapter.ChapterId == request.ChapterId)
            .Where(chapter => chapter.ChapterType == ChapterType.NotVersioned)
            .SingleOrDefaultAsync(cancellationToken);
        
        if (unversionedChapter is null)
            return HandlerResultFailureHelper.NotFoundFailure<ChapterWithLessonsWithVersions>(
                FailureMessages.Curriculum.OriginalUnversionedChapterNotFound);

        var versionedChapters = _context.VersionedModule
            .Where(chapter => chapter.ChapterId == request.ChapterId)
            .OrderByDescending(chapter => chapter.VersionedOnDate)
            .ToList();

        var chapterWithLessons = new ChapterWithLessonsWithVersions
        {
            Chapter = unversionedChapter,
            Lessons = unversionedChapter.Lessons.Count,
            Versions = versionedChapters.Count,
            VersionedModule = versionedChapters.FirstOrDefault()
        };

        return HandlerResult<ChapterWithLessonsWithVersions>.Success(chapterWithLessons);
    }
}