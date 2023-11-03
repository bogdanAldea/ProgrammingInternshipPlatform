using MediatR;
using ProgrammingInternshipPlatform.Application.Abstractions.Handlers;
using ProgrammingInternshipPlatform.Application.Abstractions.Requests;
using ProgrammingInternshipPlatform.Application.ResultPattern;
using ProgrammingInternshipPlatform.Dal.Context;
using ProgrammingInternshipPlatform.Dal.Queries.Topics;
using ProgrammingInternshipPlatform.Domain.GeneralCurriculumManagement.Topics.Models;
using ProgrammingInternshipPlatform.Domain.Shared.ErrorHandling.Exceptions;

namespace ProgrammingInternshipPlatform.Application.GeneralCurriculumManagement.General.CreateVersionOfTopic;

public record CreateVersionOfTopicCommand(TopicId TopicId) : IApplicationRequest<Guid, object>;

public class CreateVersionOfTopicHandler : IApplicationHandler<CreateVersionOfTopicCommand, Guid, object>
{
    private readonly ProgrammingInternshipPlatformDbContext _context;
    private readonly IPublisher _publisher;

    public CreateVersionOfTopicHandler(ProgrammingInternshipPlatformDbContext context, IPublisher publisher)
    {
        _context = context;
        _publisher = publisher;
    }
    
    public async Task<HandlerResult<Guid, object>> Handle(CreateVersionOfTopicCommand request, CancellationToken cancellationToken)
    {
        var topicToVersion = _context.GetTopicById(request.TopicId);
        await using var transaction = await _context.Database.BeginTransactionAsync(cancellationToken);

        try
        {
            var versionedTopic = await topicToVersion.Clone(cancellationToken);
            topicToVersion.DomainEvents
                .ToList()
                .ForEach(domainEvent => _publisher.Publish(domainEvent, cancellationToken));
            await _context.SaveChangesAsync(cancellationToken);
            return HandlerResult<Guid, object>.CreateSuccessful(versionedTopic.TopicId.Value);
        }
        catch (DomainModelValidationException exception)
        {
            return HandlerResult<Guid, object>.DomainValidationFailure(exception.DomainValidationFailures);
        }

        catch (Exception exception)
        {
            return HandlerResult<Guid, object>.InternalServerFailure(exception);
        }
    }
}