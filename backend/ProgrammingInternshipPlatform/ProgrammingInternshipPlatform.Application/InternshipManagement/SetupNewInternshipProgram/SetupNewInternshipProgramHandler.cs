using MediatR;
using ProgrammingInternshipPlatform.Application.ResultPattern;
using ProgrammingInternshipPlatform.Dal.Context;
using ProgrammingInternshipPlatform.Domain.Internships.Models;
using ProgrammingInternshipPlatform.Domain.Shared.Exceptions;

namespace ProgrammingInternshipPlatform.Application.InternshipManagement.SetupNewInternshipProgram;

public class
    SetupNewInternshipProgramHandler : IRequestHandler<SetupNewInternshipProgramCommand, HandlerResult<Internship>>
{
    private readonly ProgrammingInternshipPlatformDbContext _context;

    public SetupNewInternshipProgramHandler(ProgrammingInternshipPlatformDbContext context)
    {
        _context = context;
    }

    public async Task<HandlerResult<Internship>> Handle(SetupNewInternshipProgramCommand request,
        CancellationToken cancellationToken)
    {
        try
        {
            return await HandleInternshipSetUp(request, cancellationToken);
        }
        catch (DomainModelValidationException exception)
        {
            return HandleDomainModelError(exception.Message);
        }
    }

    private async Task<HandlerResult<Internship>> HandleInternshipSetUp(SetupNewInternshipProgramCommand request,
        CancellationToken cancellationToken)
    {
        var internshipToSetUp = await SetUpNewInternshipAsync(request);
        var newInternshipResource = await SaveInternshipAsync(internshipToSetUp, cancellationToken);
        return HandlerResult<Internship>.Success(newInternshipResource);
    }

    private async Task<Internship> SetUpNewInternshipAsync(SetupNewInternshipProgramCommand request)
    {
        return await Internship.SetupInternship(locationId: request.LocationId,
            maxInternsToEnroll: request.MaximumInternsToEnroll, durationInMonths: request.DurationInMonths,
            startDate: request.ScheduledToStartOnDate, endDate: request.ScheduledToEndOnDate);
    }

    private async Task<Internship> SaveInternshipAsync(Internship internship, CancellationToken cancellationToken)
    {
        var newInternshipResource = await _context.Internships.AddAsync(internship, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return newInternshipResource.Entity;
    }

    private HandlerResult<Internship> HandleDomainModelError(string exceptionMessage)
    {
        var domainValidationError = ApplicationError.DomainValidationFailure(exceptionMessage);
        return HandlerResult<Internship>.Fail(domainValidationError);
    }
}