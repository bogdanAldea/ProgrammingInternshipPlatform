using ProgrammingInternshipPlatform.Application.Abstractions.Handlers;
using ProgrammingInternshipPlatform.Application.Abstractions.Requests;
using ProgrammingInternshipPlatform.Application.ResultPattern;
using ProgrammingInternshipPlatform.Dal.Context;
using ProgrammingInternshipPlatform.Domain.GeneralCurriculumManagement.Topics.Models;
using ProgrammingInternshipPlatform.Domain.Shared.ErrorHandling.Exceptions;

namespace ProgrammingInternshipPlatform.Application.GeneralCurriculumManagement.General.CreateGeneralTopic;

public record CreateNewGeneralTopicCommand(string Title, string Description) : IApplicationRequest<Guid, object>;

public class CreateNewGeneralTopicHandler : IApplicationHandler<CreateNewGeneralTopicCommand, Guid, object>
{
    private readonly ProgrammingInternshipPlatformDbContext _context;

    public CreateNewGeneralTopicHandler(ProgrammingInternshipPlatformDbContext context)
    {
        _context = context;
    }
    public async Task<HandlerResult<Guid, object>> Handle(CreateNewGeneralTopicCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var newTopic = await Topic.CreateUnversionedTopic(title: request.Title, description: request.Description, 6,
                cancellationToken);
            var created = await _context.Topics.AddAsync(newTopic, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return HandlerResult<Guid, object>.CreateSuccessful(created.Entity.TopicId.Value);
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