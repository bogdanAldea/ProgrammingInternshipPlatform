using Microsoft.EntityFrameworkCore;
using ProgrammingInternshipPlatform.Dal.Context;
using ProgrammingInternshipPlatform.Domain.GeneralCurriculum.GeneralCurriculum.Chapter.Enums;
using ProgrammingInternshipPlatform.Domain.GeneralCurriculum.GeneralCurriculum.Chapter.Models;

namespace ProgrammingInternshipPlatform.Dal.GeneralCurriculum;

public static class ChapterRetrieval
{
    public static IQueryable<Chapter> WithLessons(this IQueryable<Chapter> queryable)
        => queryable.Include(chapter => chapter.Lessons);

    public static IQueryable<Chapter> WithAssignmentForEachLesson(this IQueryable<Chapter> queryable)
        => queryable.Include(chapter => chapter.Lessons)
            .ThenInclude(lesson => lesson.Assignment);

    public static IQueryable<Chapter> WithResourcesForEachLesson(this IQueryable<Chapter> queryable)
        => queryable.Include(chapter => chapter.Lessons)
            .ThenInclude(lesson => lesson.LearningResources);

    public static IQueryable<Chapter> AsVersioned(this IQueryable<Chapter> queryable)
        => queryable.Where(chapter => chapter.ChapterType == ChapterType.Versioned);
    
    public static IQueryable<Chapter> AsNonVersioned(this IQueryable<Chapter> queryable)
        => queryable.Where(chapter => chapter.ChapterType == ChapterType.NotVersioned);

    public static IQueryable<Chapter> AsReadyForVersioning(this IQueryable<Chapter> queryable)
        => queryable.Where(chapter => chapter.VersioningState == VersioningState.ReadyForVersioning);
    
    public static IQueryable<Chapter> AsNotReadyForVersioning(this IQueryable<Chapter> queryable)
        => queryable.Where(chapter => chapter.VersioningState == VersioningState.NotReadyForVersioning);

    public static IQueryable<Chapter> OrderedBySyllabusOrder(this IQueryable<Chapter> queryable)
        => queryable.OrderBy(chapter => chapter.SyllabusOrder);
}