using Microsoft.EntityFrameworkCore;
using ProgrammingInternshipPlatform.Application.Abstractions.Handlers;
using ProgrammingInternshipPlatform.Application.Abstractions.Requests;
using ProgrammingInternshipPlatform.Application.GeneralCurriculumManagement.Responses;
using ProgrammingInternshipPlatform.Application.ResultPattern;
using ProgrammingInternshipPlatform.Dal.Context;
using ProgrammingInternshipPlatform.Dal.Queries.Modules;
using ProgrammingInternshipPlatform.Dal.Queries.Topics;
using ProgrammingInternshipPlatform.Domain.GeneralCurriculumManagement.Topics.Enums;
using ProgrammingInternshipPlatform.Domain.GeneralCurriculumManagement.Topics.Models;

namespace ProgrammingInternshipPlatform.Application.GeneralCurriculumManagement.General.GetAllGeneralTopics;

public record GetAllGeneralTopicsQuery() : IApplicationCollectionRequest<TopicWithVersionsResponse, object>;

public class GetAllGeneralTopicsHandler : IApplicationCollectionHandler<GetAllGeneralTopicsQuery, TopicWithVersionsResponse, object>
{
    private readonly ProgrammingInternshipPlatformDbContext _context;

    public GetAllGeneralTopicsHandler(ProgrammingInternshipPlatformDbContext context)
    {
        _context = context;
    }
    
    public Task<HandlerResult<IReadOnlyList<TopicWithVersionsResponse>, object>> Handle(GetAllGeneralTopicsQuery request, 
        CancellationToken cancellationToken)
    {
        var generalTopics = _context.GetAllOrderedUnversionedTopicsWithLessons();
        var mappedGeneralTopics = new List<TopicWithVersionsResponse>();
        MapToResponseForEachResource(generalTopics.ToList(), mappedGeneralTopics);

        var handlerResult = HandlerResult<IReadOnlyList<TopicWithVersionsResponse>, object>
            .ReadSuccessful(mappedGeneralTopics);
        return Task.FromResult(handlerResult);
    }

    private void MapToResponseForEachResource(IReadOnlyList<Topic> unversionedTopics, 
        List<TopicWithVersionsResponse> mappedResponses)
    {
        foreach (var topic in unversionedTopics)
        {
            var versions = _context.GetModulesForTopic(topic.TopicId);
            var latestVersion = versions
                .OrderByDescending(version => version.VersionedOnDate)
                .SingleOrDefault();
            var unversionedTopic = TopicWithVersionsResponse.CreateFromResource(topic, latestVersion, versions.Count);
            mappedResponses.Add(unversionedTopic);
        }
    }
}