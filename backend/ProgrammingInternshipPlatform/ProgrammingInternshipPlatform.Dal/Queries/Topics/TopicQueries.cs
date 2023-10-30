using Microsoft.EntityFrameworkCore;
using ProgrammingInternshipPlatform.Domain.GeneralCurriculumManagement.Topics.Enums;
using ProgrammingInternshipPlatform.Domain.GeneralCurriculumManagement.Topics.Models;

namespace ProgrammingInternshipPlatform.Dal.Queries.Topics;

public static class TopicQueries
{
    public static IQueryable<Topic> WithLessons(this IQueryable<Topic> queryable)
        => queryable.Include(topic => topic.Lessons);

    public static IQueryable<Topic> WithAssignmentForEachLesson(this IQueryable<Topic> queryable)
        => queryable
            .Include(topic => topic.Lessons)
            .ThenInclude(lesson => lesson.Assignment);
    
    public static IQueryable<Topic> WithLearningResourcesForEachLesson(this IQueryable<Topic> queryable)
        => queryable
            .Include(topic => topic.Lessons)
            .ThenInclude(lesson => lesson.LearningResources);

    public static IQueryable<Topic> AsVersioned(this IQueryable<Topic> queryable)
        => queryable
            .Where(topic => topic.TopicType == TopicType.Versioned);
    
    public static IQueryable<Topic> AsUnversioned(this IQueryable<Topic> queryable)
        => queryable
            .Where(topic => topic.TopicType == TopicType.NotVersioned);
    
    public static IQueryable<Topic> OrderedBySyllabusOrder(this IQueryable<Topic> queryable)
        => queryable
            .OrderBy(topic => topic.SyllabusOrder);
}