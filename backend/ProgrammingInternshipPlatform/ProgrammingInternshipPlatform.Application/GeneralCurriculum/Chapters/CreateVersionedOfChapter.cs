using Microsoft.EntityFrameworkCore;
using ProgrammingInternshipPlatform.Application.Abstractions.Handlers;
using ProgrammingInternshipPlatform.Application.Abstractions.Requests;
using ProgrammingInternshipPlatform.Application.ResultPattern;
using ProgrammingInternshipPlatform.Dal.Context;
using ProgrammingInternshipPlatform.Domain.GeneralCurriculum.GeneralCurriculum.Chapter.Enums;
using ProgrammingInternshipPlatform.Domain.GeneralCurriculum.GeneralCurriculum.Chapter.Identifiers;
using ProgrammingInternshipPlatform.Domain.GeneralCurriculum.GeneralCurriculum.Chapter.Models;
using ProgrammingInternshipPlatform.Domain.ModuleVersioning.VersionedModules.Model;
using ProgrammingInternshipPlatform.Domain.Shared.ErrorHandling.Exceptions;

namespace ProgrammingInternshipPlatform.Application.GeneralCurriculum.Chapters;

public record CreateVersionedOfChapterCommand(ChapterId ChapterId) : IApplicationRequest<Chapter>;

public class CreateVersionOfChapterHandler : IApplicationHandler<CreateVersionedOfChapterCommand, Chapter>
{

    private readonly ProgrammingInternshipPlatformDbContext _context;

    public CreateVersionOfChapterHandler(ProgrammingInternshipPlatformDbContext context)
    {
        _context = context;
    }
    
    public async Task<HandlerResult<Chapter>> Handle(CreateVersionedOfChapterCommand request, CancellationToken cancellationToken)
    {
        var originalChapterToVersion = await _context.Chapter
            .Include(chapter => chapter.Lessons)
            .ThenInclude(lesson => lesson.LearningResources)
            .Include(chapter => chapter.Lessons)
            .ThenInclude(lesson => lesson.Assignment)
            .Where(chapter => chapter.ChapterId == request.ChapterId 
                              && chapter.ChapterType == ChapterType.NotVersioned)
            .SingleOrDefaultAsync(cancellationToken);

        if (originalChapterToVersion is null)
            return HandlerResultFailureHelper.NotFoundFailure<Chapter>(
                FailureMessages.Curriculum.OriginalUnversionedChapterNotFound);

        var currentChapterVersions = _context.VersionedModule
            .Count(chapter => chapter.ChapterId == request.ChapterId) + 1;

        try
        {
            var versionedChapter = await originalChapterToVersion.CreateVersionOfChapter(cancellationToken);
            var created = await _context.AddAsync(versionedChapter, cancellationToken);

            var versionedModule = VersionedModule.CreateVersionedModule(originalChapterToVersion.ChapterId.Value, currentChapterVersions);
            await _context.VersionedModule.AddAsync(versionedModule, cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);
            return HandlerResult<Chapter>.Success();
        }
        catch (DomainModelValidationException exception)
        {
            return HandlerResultFailureHelper.DomainValidationFailure<Chapter>(exception.DomainValidationFailure!);
        }
    }
}