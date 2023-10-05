using Microsoft.EntityFrameworkCore;
using ProgrammingInternshipPlatform.Dal.Context;
using ProgrammingInternshipPlatform.Domain.GeneralCurriculum.GeneralCurriculum.Chapter.Identifiers;
using ProgrammingInternshipPlatform.Domain.GeneralCurriculum.GeneralCurriculum.Chapter.Models;

namespace ProgrammingInternshipPlatform.Dal.GeneralCurriculum;

public static class CurriculumRetrieval
{
    public static IReadOnlyList<Chapter> GetAllChapters(this ProgrammingInternshipPlatformDbContext context)
        => context.Chapter.ToList();

    public static IReadOnlyList<Chapter> GetAllChaptersFullyConfigured(
        this ProgrammingInternshipPlatformDbContext context)
        => context.Chapter
            .WithAssignmentForEachLesson()
            .WithResourcesForEachLesson()
            .ToList();

    public static IReadOnlyList<Chapter> GetAllUnversionedChapters(this ProgrammingInternshipPlatformDbContext context)
        => context.Chapter
            .AsNonVersioned()
            .ToList();

    public static async Task<IReadOnlyList<Chapter>> GetOrdererUnversionedChaptersWithLessons(
        this ProgrammingInternshipPlatformDbContext context, CancellationToken cancellationToken)
        => await context.Chapter
            .WithLessons()
            .AsNonVersioned()
            .OrderedBySyllabusOrder()
            .ToListAsync(cancellationToken);

    public static async Task<Chapter?> GetUnversionedChapterWithAssignmentForEachLesson(
        this ProgrammingInternshipPlatformDbContext context, ChapterId chapterId, CancellationToken cancellationToken)
        => await context.Chapter
            .Where(chapter => chapter.ChapterId == chapterId)
            .AsNonVersioned()
            .WithAssignmentForEachLesson()
            .SingleOrDefaultAsync(cancellationToken);
}