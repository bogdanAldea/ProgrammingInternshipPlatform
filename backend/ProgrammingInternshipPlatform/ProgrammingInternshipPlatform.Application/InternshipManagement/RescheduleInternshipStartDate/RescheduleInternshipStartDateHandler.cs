using MediatR;
using Microsoft.EntityFrameworkCore;
using ProgrammingInternshipPlatform.Application.ResultPattern;
using ProgrammingInternshipPlatform.Dal.Context;
using ProgrammingInternshipPlatform.Domain.Internships.Identifiers;
using ProgrammingInternshipPlatform.Domain.Internships.Models;
using ProgrammingInternshipPlatform.Domain.Shared.Exceptions;

namespace ProgrammingInternshipPlatform.Application.InternshipManagement.RescheduleInternshipStartDate;

public class
    RescheduleInternshipStartDateHandler : IRequestHandler<RescheduleInternshipStartDateCommand,
        HandlerResult<Internship>>
{
    private readonly ProgrammingInternshipPlatformDbContext _context;

    public RescheduleInternshipStartDateHandler(ProgrammingInternshipPlatformDbContext context)
    {
        _context = context;
    }
    
    public async Task<HandlerResult<Internship>> Handle(RescheduleInternshipStartDateCommand request,
        CancellationToken cancellationToken)
    {
        var internshipToReschedule = await RetrieveInternship(request.InternshipId, cancellationToken);

        if (internshipToReschedule is null)
        {
            return HandleResourceNotFoundError();
        }

        try
        {
            var rescheduledInternship = await HandleReschedulingInternshipStartDate(internshipToReschedule,
                request.RescheduledStartDate, cancellationToken);
            return HandlerResult<Internship>.Success(rescheduledInternship);
        }
        catch (DomainModelValidationException exception)
        {
            return HandleDomainModelValidationError(exception.Message);
        }
    }

    private async Task<Internship?> RetrieveInternship(InternshipId id, CancellationToken cancellationToken)
    {
        return await _context.Internships
            .Include(internship => internship.Timeframe)
            .FirstOrDefaultAsync(internship => internship.Id == id, cancellationToken);
    }
    
    private HandlerResult<Internship> HandleResourceNotFoundError()
    {
        var notFoundError =
            ApplicationError.NotFoundFailure(ApplicationErrorMessages.InternshipMessages.InternshipNotFound);
        return HandlerResult<Internship>.Fail(notFoundError);
    }

    private async Task<Internship> HandleReschedulingInternshipStartDate(Internship internship, DateTime rescheduledStartDate,
        CancellationToken cancellationToken)
    {
        await internship.RescheduleInternshipStartDate(rescheduledStartDate, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return internship;
    }

    private HandlerResult<Internship> HandleDomainModelValidationError(string exceptionMessage)
    {
        var domainValidationError = ApplicationError.DomainValidationFailure(exceptionMessage);
        return HandlerResult<Internship>.Fail(domainValidationError);
    }
}