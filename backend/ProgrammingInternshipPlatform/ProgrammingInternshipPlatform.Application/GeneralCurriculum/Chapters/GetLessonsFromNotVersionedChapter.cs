using Microsoft.EntityFrameworkCore;
using ProgrammingInternshipPlatform.Application.Abstractions.Handlers;
using ProgrammingInternshipPlatform.Application.Abstractions.Requests;
using ProgrammingInternshipPlatform.Application.GeneralCurriculum.Contracts.Responses;
using ProgrammingInternshipPlatform.Application.ResultPattern;
using ProgrammingInternshipPlatform.Dal.Context;
using ProgrammingInternshipPlatform.Domain.GeneralCurriculum.GeneralCurriculum.Chapter.Enums;
using ProgrammingInternshipPlatform.Domain.GeneralCurriculum.GeneralCurriculum.Chapter.Identifiers;

namespace ProgrammingInternshipPlatform.Application.GeneralCurriculum.Chapters;

public record GetUnversionedChapterWithLessonsQuery(ChapterId ChapterId) : IApplicationRequest<ChapterWithLessonsWithVersions>;

public class GetUnversionedChapterWithLessonsHandler 
    : IApplicationHandler<GetUnversionedChapterWithLessonsQuery, ChapterWithLessonsWithVersions>
{
    private readonly ProgrammingInternshipPlatformDbContext _context;

    public GetUnversionedChapterWithLessonsHandler(ProgrammingInternshipPlatformDbContext context)
    {
        _context = context;
    }
    
    public async Task<HandlerResult<ChapterWithLessonsWithVersions>> Handle(GetUnversionedChapterWithLessonsQuery request, 
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

        var versionedChapters = await _context.VersionedModule
            .Where(chapter => chapter.ChapterId == request.ChapterId)
            .OrderByDescending(chapter => chapter.VersionedOnDate)
            .ToListAsync(cancellationToken);

        var chapterWithLessons = new ChapterWithLessonsWithVersions
        {
            Chapter = unversionedChapter,
            VersionedModules = versionedChapters,
            Lessons = unversionedChapter.Lessons,
            Versions = versionedChapters.Count
        };

        return HandlerResult<ChapterWithLessonsWithVersions>.Success(chapterWithLessons);
    }
}