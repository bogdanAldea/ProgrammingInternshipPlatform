using Microsoft.EntityFrameworkCore;
using ProgrammingInternshipPlatform.Application.Abstractions.Handlers;
using ProgrammingInternshipPlatform.Application.Abstractions.Requests;
using ProgrammingInternshipPlatform.Application.ResultPattern;
using ProgrammingInternshipPlatform.Dal.Context;
using ProgrammingInternshipPlatform.Dal.GeneralCurriculum;
using ProgrammingInternshipPlatform.Domain.GeneralCurriculum.GeneralCurriculum.Chapter.Identifiers;
using ProgrammingInternshipPlatform.Domain.GeneralCurriculum.GeneralCurriculum.Chapter.Models;
using ProgrammingInternshipPlatform.Domain.GeneralCurriculum.GeneralCurriculum.Lesson.Model;

namespace ProgrammingInternshipPlatform.Application.GeneralCurriculum.Chapters;

public record GetLessonsFromUnversionedChapterQuery(ChapterId ChapterId) : IApplicationCollectionRequest<Lesson>;

public class
    GetLessonsFromUnversionedChapterHandler : IApplicationCollectionHandler<GetLessonsFromUnversionedChapterQuery,
        Lesson>
{
    private readonly ProgrammingInternshipPlatformDbContext _context;

    public GetLessonsFromUnversionedChapterHandler(ProgrammingInternshipPlatformDbContext context)
    {
        _context = context;
    }

    public async Task<HandlerResult<IReadOnlyList<Lesson>>> Handle(GetLessonsFromUnversionedChapterQuery request,
        CancellationToken cancellationToken)
    {
        var chapter = await GetUnversionedChapterWithAssignmentForEachLesson(request.ChapterId, cancellationToken);

        if (chapter is null)
            return HandlerResultFailureHelper.NotFoundFailure<IReadOnlyList<Lesson>>(FailureMessages.Curriculum
                .OriginalUnversionedChapterNotFound);

        var orderedLessons = OrderLessonsBySyllabus(chapter.Lessons);

        return HandlerResult<IReadOnlyList<Lesson>>.Success(orderedLessons);
    }

    private async Task<Chapter?> GetUnversionedChapterWithAssignmentForEachLesson(ChapterId chapterId,
        CancellationToken cancellationToken)
        => await _context.GetUnversionedChapterWithAssignmentForEachLesson(chapterId, cancellationToken);

    private IReadOnlyList<Lesson> OrderLessonsBySyllabus(IReadOnlyList<Lesson> lessons)
        => lessons.OrderBy(lesson => lesson.SyllabusOrder).ToList();
}