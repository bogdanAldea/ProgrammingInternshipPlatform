using System.Collections.Immutable;
using ProgrammingInternshipPlatform.Application.Abstractions.Handlers;
using ProgrammingInternshipPlatform.Application.Abstractions.Requests;
using ProgrammingInternshipPlatform.Application.GeneralCurriculumManagement.Responses;
using ProgrammingInternshipPlatform.Application.ResultPattern;
using ProgrammingInternshipPlatform.Dal.Context;
using ProgrammingInternshipPlatform.Dal.Queries.Topics;
using ProgrammingInternshipPlatform.Domain.GeneralCurriculumManagement.Topics.Models;

namespace ProgrammingInternshipPlatform.Application.GeneralCurriculumManagement.Versioned.GetVersionedTopics;

public record GetAllVersionsOfTopicQuery(TopicId TopicId) : IApplicationCollectionRequest<TopicPartialResponse, object>;

public class GetAllVersionsOfTopicHandler : IApplicationCollectionHandler<GetAllVersionsOfTopicQuery, TopicPartialResponse, object>
{
    private readonly ProgrammingInternshipPlatformDbContext _context;

    public GetAllVersionsOfTopicHandler(ProgrammingInternshipPlatformDbContext context)
    {
        _context = context;
    }
    public Task<HandlerResult<IReadOnlyList<TopicPartialResponse>, object>> Handle(GetAllVersionsOfTopicQuery request, CancellationToken cancellationToken)
    {
        var requestedTopicVersions = _context.GetAllVersionsOfTopic(request.TopicId);
        var mappedVersions = MapRequestedTopicVersions(requestedTopicVersions);
        var handlerResult = HandlerResult<IReadOnlyList<TopicPartialResponse>, object>.ReadSuccessful(mappedVersions);
        return Task.FromResult(handlerResult);
    }

    private IReadOnlyList<TopicPartialResponse> MapRequestedTopicVersions(IReadOnlyList<Topic> topicVersions)
    {
        var mappedVersions = new List<TopicPartialResponse>();
        foreach (var version in topicVersions)
        {
            var mappedVersion = TopicPartialResponse.CreateFromTopic(version);
            mappedVersions.Add(mappedVersion);
        }

        return mappedVersions.ToImmutableList();
    }
}