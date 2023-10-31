using ProgrammingInternshipPlatform.Application.Abstractions.Handlers;
using ProgrammingInternshipPlatform.Application.Abstractions.Requests;
using ProgrammingInternshipPlatform.Application.GeneralCurriculumManagement.Responses;
using ProgrammingInternshipPlatform.Application.ResultPattern;
using ProgrammingInternshipPlatform.Application.ResultPattern.FailureReason;
using ProgrammingInternshipPlatform.Dal.Context;
using ProgrammingInternshipPlatform.Dal.Queries.Topics;
using ProgrammingInternshipPlatform.Domain.GeneralCurriculumManagement.Topics.Models;

namespace ProgrammingInternshipPlatform.Application.GeneralCurriculumManagement.ViewTopicReadyForVersioning;

public record ViewTopicReadyForVersioningQuery(TopicId TopicId) : IApplicationRequest<TopicReadyForVersioningResponse, object>;

public class ViewTopicReadyForVersioningHandler : IApplicationHandler<ViewTopicReadyForVersioningQuery, TopicReadyForVersioningResponse, object>
{
    private readonly ProgrammingInternshipPlatformDbContext _context;

    public ViewTopicReadyForVersioningHandler(ProgrammingInternshipPlatformDbContext context)
    {
        _context = context;
    }
    
    public Task<HandlerResult<TopicReadyForVersioningResponse, object>> Handle(ViewTopicReadyForVersioningQuery request, CancellationToken cancellationToken)
    {
        var topicReadyForVersioning = _context.GetTopicReadyForVersioningWithLessons(request.TopicId);

        if (topicReadyForVersioning is null)
        {
            var notFountResult = HandlerResult<TopicReadyForVersioningResponse, object>
                .NotFoundFailure(FailureMessages.GeneralCurriculum.UnversionedChapterNotFound);
            return Task.FromResult(notFountResult);
        }

        var mappedTopicResponse = new TopicReadyForVersioningResponse(topicReadyForVersioning);
        var successResult =  HandlerResult<TopicReadyForVersioningResponse, object>.ReadSuccessful(mappedTopicResponse);
        return Task.FromResult(successResult);
    }
}