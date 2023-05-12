using MediatR;
using Microsoft.EntityFrameworkCore;
using ProgrammingInternshipPlatform.Application.ResultPattern;
using ProgrammingInternshipPlatform.Dal.Context;
using ProgrammingInternshipPlatform.Domain.InternshipManagement.Internship;
using ProgrammingInternshipPlatform.Domain.Shared.Exceptions;

namespace ProgrammingInternshipPlatform.Application.InternshipManagement.ExtendInternshipEndDate;

public record ExtendInternshipEndDateCommand(InternshipId InternshipId, DateTime ExtendedEndDate) 
    : IRequest<HandlerResult<Internship>>;

public class ExtendInternshipEndDateHandler : IRequestHandler<ExtendInternshipEndDateCommand, HandlerResult<Internship>>
{
    private readonly ProgrammingInternshipPlatformDbContext _context;

    public ExtendInternshipEndDateHandler(ProgrammingInternshipPlatformDbContext context)
    {
        _context = context;
    }

    public async Task<HandlerResult<Internship>> Handle(ExtendInternshipEndDateCommand request,
        CancellationToken cancellationToken)
    {
        var internship = await RetrieveInternship(request.InternshipId, cancellationToken);

        if (internship is null)
        {
            return HandleInternshipNotFoundError();
        }

        try
        {
            return await HandleInternshipEndDateExtension(internship: internship,
                extendedEndDate: request.ExtendedEndDate, cancellationToken: cancellationToken);
        }
        catch (DomainModelValidationException exception)
        {
            return HandleDomainModelValidationError(exception.Message);
        }
    }

    private async Task<Internship?> RetrieveInternship(InternshipId internshipId, CancellationToken cancellationToken)
    {
        return await _context.Internships
            .Include(internship => internship.Timeframe)
            .FirstOrDefaultAsync(internship => internship.Id == internshipId, cancellationToken);
    }

    private HandlerResult<Internship> HandleInternshipNotFoundError()
    {
        var applicationError =
            ApplicationError.NotFoundFailure(ApplicationErrorMessages.InternshipMessages.InternshipNotFound);
        return HandlerResult<Internship>.Fail(applicationError);
    }

    private async Task<HandlerResult<Internship>> HandleInternshipEndDateExtension(Internship internship,
        DateTime extendedEndDate, CancellationToken cancellationToken)
    {
        await internship.ExtendInternshipEndDate(extendedEndDate, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return HandlerResult<Internship>.Success(internship);
    }

    private HandlerResult<Internship> HandleDomainModelValidationError(string? errorMessage)
    {
        var applicationError = ApplicationError.DomainValidationFailure(errorMessage);
        return HandlerResult<Internship>.Fail(applicationError);
    }
}