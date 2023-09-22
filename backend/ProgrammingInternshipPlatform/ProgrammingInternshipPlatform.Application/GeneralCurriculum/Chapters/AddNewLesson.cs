using Microsoft.EntityFrameworkCore;
using ProgrammingInternshipPlatform.Application.Abstractions.Handlers;
using ProgrammingInternshipPlatform.Application.Abstractions.Requests;
using ProgrammingInternshipPlatform.Application.ResultPattern;
using ProgrammingInternshipPlatform.Dal.Context;
using ProgrammingInternshipPlatform.Domain.GeneralCurriculum.GeneralCurriculum.Chapter.Enums;
using ProgrammingInternshipPlatform.Domain.GeneralCurriculum.GeneralCurriculum.Chapter.Identifiers;
using ProgrammingInternshipPlatform.Domain.GeneralCurriculum.GeneralCurriculum.Lesson.Model;
using ProgrammingInternshipPlatform.Domain.Shared.ErrorHandling.Exceptions;

namespace ProgrammingInternshipPlatform.Application.GeneralCurriculum.Chapters;

public record AddNewLessonToNotVersionedChapterCommand(ChapterId ChapterId, string Title, string Description,
    string LearningObjective) : IApplicationRequest<Lesson>;

public class
    AddNewLessonToNotVersionedChapterHandler : IApplicationHandler<AddNewLessonToNotVersionedChapterCommand, Lesson>
{
    private readonly ProgrammingInternshipPlatformDbContext _context;

    public AddNewLessonToNotVersionedChapterHandler(ProgrammingInternshipPlatformDbContext context)
    {
        _context = context;
    }

    public async Task<HandlerResult<Lesson>> Handle(AddNewLessonToNotVersionedChapterCommand request,
        CancellationToken cancellationToken)
    {
        var chapterToAddLessonTo = await _context.Chapter
            .Include(chapter => chapter.Lessons)
            .Where(chapter => chapter.ChapterId == request.ChapterId)
            .Where(chapter => chapter.ChapterType == ChapterType.NotVersioned)
            .SingleOrDefaultAsync(cancellationToken);

        if (chapterToAddLessonTo is null)
            return HandlerResultFailureHelper.NotFoundFailure<Lesson>(FailureMessages.Curriculum
                .OriginalUnversionedChapterNotFound);

        var transaction = await _context.Database.BeginTransactionAsync(cancellationToken);
        try
        {
            try
            {
                var newLesson = await Lesson.CreateNew(chapterToAddLessonTo.ChapterId, request.Title, request.Description,
                    request.LearningObjective, chapterToAddLessonTo.Lessons.Count, cancellationToken);

                await chapterToAddLessonTo.AddLesson(newLesson, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);
                return HandlerResult<Lesson>.Success();
            }
            catch (DomainModelValidationException exception)
            {
                return HandlerResultFailureHelper.DomainValidationFailure<Lesson>(exception.DomainValidationFailure!);
            }
        }
        catch (Exception)
        {
            await transaction.RollbackAsync(cancellationToken);
            return HandlerResultFailureHelper.TransactionFailure<Lesson>("");
        }
    }
}