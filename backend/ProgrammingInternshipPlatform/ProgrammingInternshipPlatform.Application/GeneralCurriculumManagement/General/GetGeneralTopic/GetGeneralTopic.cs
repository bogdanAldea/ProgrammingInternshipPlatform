using Microsoft.EntityFrameworkCore;
using ProgrammingInternshipPlatform.Application.Abstractions.Handlers;
using ProgrammingInternshipPlatform.Application.Abstractions.Requests;
using ProgrammingInternshipPlatform.Application.GeneralCurriculumManagement.Responses;
using ProgrammingInternshipPlatform.Application.ResultPattern;
using ProgrammingInternshipPlatform.Application.ResultPattern.FailureReason;
using ProgrammingInternshipPlatform.Dal.Context;
using ProgrammingInternshipPlatform.Domain.GeneralCurriculumManagement.Topics.Models;

namespace ProgrammingInternshipPlatform.Application.GeneralCurriculumManagement.General;

public record GetGeneralTopicQuery(TopicId TopicId) : IApplicationRequest<TopicResponse, object>;

public class GetGeneralTopicHandler : IApplicationHandler<GetGeneralTopicQuery, TopicResponse, object>
{
    private readonly ProgrammingInternshipPlatformDbContext _context;

    public GetGeneralTopicHandler(ProgrammingInternshipPlatformDbContext context)
    {
        _context = context;
    }
    public async Task<HandlerResult<TopicResponse, object>> Handle(GetGeneralTopicQuery request, CancellationToken cancellationToken)
    {
        var topic = await _context.Topics.SingleOrDefaultAsync(topic => topic.TopicId == request.TopicId, cancellationToken);
        
        if (topic is null)
            return HandlerResult<TopicResponse, object>.NotFoundFailure(FailureMessages.GeneralCurriculum
                .UnversionedChapterNotFound);
        
        var mappedTopic = TopicResponse.CreateFromTopic(topic);
        return HandlerResult<TopicResponse, object>.ReadSuccessful(mappedTopic);
    }
}