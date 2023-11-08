using ProgrammingInternshipPlatform.Application.Abstractions.Handlers;
using ProgrammingInternshipPlatform.Application.Abstractions.Requests;
using ProgrammingInternshipPlatform.Application.ResultPattern;
using ProgrammingInternshipPlatform.Dal.Context;
using ProgrammingInternshipPlatform.Domain.AccountManagement.Identifiers;
using ProgrammingInternshipPlatform.Domain.InternshipManagement.Internships.Models;
using ProgrammingInternshipPlatform.Domain.Shared.ErrorHandling.Exceptions;

namespace ProgrammingInternshipPlatform.Application.InternshipManagement.ScheduleInternship;

public record ScheduleInternshipCommand(AccountId CoordinatorId, int DurationInMonths, int MaxInternsToEnroll,
    DateTime ScheduledStartDate) : IApplicationRequest<Guid, object>;

public class ScheduleInternshipHandler : IApplicationHandler<ScheduleInternshipCommand, Guid, object>
{
    private readonly ProgrammingInternshipPlatformDbContext _context;

    public ScheduleInternshipHandler(ProgrammingInternshipPlatformDbContext context)
    {
        _context = context;
    }

    public async Task<HandlerResult<Guid, object>> Handle(ScheduleInternshipCommand request,
        CancellationToken cancellationToken)
    {
        try
        {
            var internship = await Internship.ScheduleNewInternship(coordinatorId: request.CoordinatorId,
                maxInternsToEnroll: request.MaxInternsToEnroll, durationInMonths: request.DurationInMonths,
                scheduleStartDate: request.ScheduledStartDate, cancellationToken: cancellationToken);

            var scheduledInternship = await _context.Internships.AddAsync(internship, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            var internshipId = scheduledInternship.Entity.InternshipId.Value;
            return HandlerResult<Guid, object>.CreateSuccessful(internshipId);
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