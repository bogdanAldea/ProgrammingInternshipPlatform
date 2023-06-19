using MediatR;
using Microsoft.EntityFrameworkCore;
using ProgrammingInternshipPlatform.Application.ResultPattern;
using ProgrammingInternshipPlatform.Dal.Context;
using ProgrammingInternshipPlatform.Domain.Account.UserAccounts;
using ProgrammingInternshipPlatform.Domain.InternshipManagement.Interns;
using ProgrammingInternshipPlatform.Domain.InternshipManagement.Internships;
using ProgrammingInternshipPlatform.Domain.Shared.ErrorHandling.Exceptions;

namespace ProgrammingInternshipPlatform.Application.InternshipManagement.EnrollInternToInternship;

public record EnrollNewInternToInternshipCommand(InternshipId InternshipId, AccountId AccountId) : 
    IRequest<HandlerResult<Internship>>;

public class EnrollNewInternToInternshipHandler : IRequestHandler<EnrollNewInternToInternshipCommand, 
    HandlerResult<Internship>>
{
    private readonly ProgrammingInternshipPlatformDbContext _context;

    public EnrollNewInternToInternshipHandler(ProgrammingInternshipPlatformDbContext context)
    {
        _context = context;
    }
    public async Task<HandlerResult<Internship>> Handle(EnrollNewInternToInternshipCommand request, CancellationToken cancellationToken)
    {
        var internshipToAddInternTo = await _context.Internships
            .Include(internship => internship.Timeframe)
            .FirstOrDefaultAsync(internship => 
            internship.Id == request.InternshipId, cancellationToken: cancellationToken);

        if (internshipToAddInternTo is null)
        {
            var notFoundMessage = ApplicationErrorMessages.InternshipMessages.InternshipNotFound;
            var internshipNotFoundError = ApplicationError.NotFoundFailure(notFoundMessage);
            return HandlerResult<Internship>.Fail(internshipNotFoundError);
        }

        Intern internToEnroll;
        try
        {
            internToEnroll = await Intern.CreateNew(accountId: request.AccountId, 
                internshipId: request.InternshipId, cancellationToken);
        }
        catch (DomainModelValidationException exception)
        {
            var domainValidationError = ApplicationError.DomainValidationFailure(exception.Message);
            return HandlerResult<Internship>.Fail(domainValidationError);
        }

        try
        {
            await internshipToAddInternTo.EnrollNewIntern(internToEnroll, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return HandlerResult<Internship>.Success();
        }
        catch (DomainModelValidationException exception)
        {
            var domainValidationError = ApplicationError.DomainValidationFailure(exception.Message);
            return HandlerResult<Internship>.Fail(domainValidationError);
        }
        catch (MaximumNumberOfInternsReachedException)
        {
            var internsEnrolledError = ApplicationErrorMessages.InternshipMessages.MaximumInternsReached;
            var internEnrollError = ApplicationError.DomainValidationFailure(internsEnrolledError);
            return HandlerResult<Internship>.Fail(internEnrollError);
        }
        
    }
}