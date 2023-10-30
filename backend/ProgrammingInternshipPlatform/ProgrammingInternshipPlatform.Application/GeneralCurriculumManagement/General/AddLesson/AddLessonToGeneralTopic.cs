using Microsoft.EntityFrameworkCore.Storage;
using ProgrammingInternshipPlatform.Application.Abstractions.Handlers;
using ProgrammingInternshipPlatform.Application.Abstractions.Requests;
using ProgrammingInternshipPlatform.Application.ResultPattern;
using ProgrammingInternshipPlatform.Dal.Context;
using ProgrammingInternshipPlatform.Domain.GeneralCurriculumManagement.Lessons.Models;
using ProgrammingInternshipPlatform.Domain.GeneralCurriculumManagement.Topics.Models;
using ProgrammingInternshipPlatform.Domain.Shared.ErrorHandling.Exceptions;

namespace ProgrammingInternshipPlatform.Application.GeneralCurriculumManagement.General.AddLesson;

public record AddLessonToGeneralTopicCommand(TopicId GeneralTopicId, string LessonTitle, string LessonDescription) 
    : IApplicationRequest<Guid, object>;

public class AddLessonToGeneralTopicHandler : IApplicationHandler<AddLessonToGeneralTopicCommand, Guid, object>
{
    private readonly ProgrammingInternshipPlatformDbContext _context;

    public AddLessonToGeneralTopicHandler(ProgrammingInternshipPlatformDbContext context)
    {
        _context = context;
    }

    public async Task<HandlerResult<Guid, object>> Handle(AddLessonToGeneralTopicCommand request,
        CancellationToken cancellationToken)
    {
        var generalTopic = _context.Topics.Single(topic => topic.TopicId == request.GeneralTopicId);
        await using var transaction = await _context.Database.BeginTransactionAsync(cancellationToken);

        try
        {
            return await AddLessonToGeneralTopic(topic: generalTopic, request: request,
                cancellationToken: cancellationToken, transaction: transaction);
        }
        catch (Exception exception)
        {
            await transaction.RollbackAsync(cancellationToken);
            return HandlerResult<Guid, object>.InternalServerFailure(exception);
        }
    }

    private async Task<HandlerResult<Guid, object>> AddLessonToGeneralTopic(Topic topic,
        AddLessonToGeneralTopicCommand request, CancellationToken cancellationToken, IDbContextTransaction transaction)
    {
        try
        {
            var newLesson = await Lesson.CreateNewLesson(title: request.LessonTitle,
                description: request.LessonDescription,
                topicId: topic.TopicId, topicOrder: 0, cancellationToken: cancellationToken);
            await topic.AddLesson(newLesson, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            await transaction.CommitAsync(cancellationToken);
            return HandlerResult<Guid, object>.UpdateSuccessful();
        }
        catch (DomainModelValidationException exception)
        {
            await transaction.RollbackAsync(cancellationToken);
            return HandlerResult<Guid, object>.DomainValidationFailure(exception.DomainValidationFailure!);
        }
    }
}