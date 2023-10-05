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
        var unversionedChapter = await 
            GetUnversionedChapterWithAssignmentForEachLesson(request.ChapterId, cancellationToken);

        if (unversionedChapter is null)
            return HandlerResultFailureHelper.NotFoundFailure<ChapterWithLessonsWithVersions>(
                FailureMessages.Curriculum.OriginalUnversionedChapterNotFound);

        var versionedChapters = 
            GetVersionedModulesOfChapterOrderedByVersionedDate(request.ChapterId);

        var chapterWithLessons = CreateResponse(unversionedChapter, versionedChapters);

        return HandlerResult<ChapterWithLessonsWithVersions>.Success(chapterWithLessons);
    }

    private async Task<Chapter?> GetUnversionedChapterWithAssignmentForEachLesson(ChapterId chapterId,
        CancellationToken cancellationToken)
        => await _context.GetUnversionedChapterWithAssignmentForEachLesson(chapterId, cancellationToken);

    private IReadOnlyList<VersionedModule> GetVersionedModulesOfChapterOrderedByVersionedDate(ChapterId chapterId)
        => _context.GetVersionedModulesOfChapterOrderedByVersionedDate(chapterId);

    private ChapterWithLessonsWithVersions CreateResponse(Chapter unversionedChapter,
        IReadOnlyList<VersionedModule> modules)
        => new() {
            Chapter = unversionedChapter,
            Lessons = unversionedChapter.Lessons.Count,
            Versions = modules.Count,
            VersionedModule = modules.FirstOrDefault()
        };
}