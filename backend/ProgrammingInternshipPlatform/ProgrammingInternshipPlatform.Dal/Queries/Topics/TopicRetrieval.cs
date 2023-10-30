using System.Collections.Immutable;
using ProgrammingInternshipPlatform.Dal.Context;
using ProgrammingInternshipPlatform.Domain.GeneralCurriculumManagement.Topics.Models;

namespace ProgrammingInternshipPlatform.Dal.Queries.Topics;

public static class TopicRetrieval
{
    public static Topic GetTopicById(this ProgrammingInternshipPlatformDbContext context, TopicId topicId)
        => context.Topics
            .AsQueryable()
            .WithAssignmentForEachLesson()
            .WithLearningResourcesForEachLesson()
            .Single(topic => topic.TopicId.Value == topicId.Value);

    public static IReadOnlyList<Topic> GetAllVersionsOfTopic(this ProgrammingInternshipPlatformDbContext context,
        TopicId topicId)
        => context.Topics
            .AsVersioned()
            .Where(topic => topic.TopicId == topicId)
            .ToImmutableList();

    public static IQueryable<Topic> GetAllOrderedUnversionedTopicsWithLessons(
        this ProgrammingInternshipPlatformDbContext context)
        => context.Topics
            /*.AsUnversioned()*/
            .OrderedBySyllabusOrder()
            .WithLessons();
}