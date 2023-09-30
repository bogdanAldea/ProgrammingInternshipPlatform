using Microsoft.EntityFrameworkCore;
using ProgrammingInternshipPlatform.Application.Abstractions.Handlers;
using ProgrammingInternshipPlatform.Application.Abstractions.Requests;
using ProgrammingInternshipPlatform.Application.ResultPattern;
using ProgrammingInternshipPlatform.Dal.Context;
using ProgrammingInternshipPlatform.Domain.GeneralCurriculum.GeneralCurriculum.Chapter.Identifiers;
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
        var chapter = await _context.Chapter
            .Include(chapter => chapter.Lessons)
            .ThenInclude(lesson => lesson.Assignment)
            .Where(chapter => chapter.ChapterId == request.ChapterId)
            .SingleOrDefaultAsync(cancellationToken);

        if (chapter is null)
            return HandlerResultFailureHelper.NotFoundFailure<IReadOnlyList<Lesson>>(FailureMessages.Curriculum
                .OriginalUnversionedChapterNotFound);

        var orderedLessons = chapter.Lessons
            .OrderBy(lesson => lesson.SyllabusOrder)
            .ToList();
        
        return HandlerResult<IReadOnlyList<Lesson>>.Success(orderedLessons);
    }
}