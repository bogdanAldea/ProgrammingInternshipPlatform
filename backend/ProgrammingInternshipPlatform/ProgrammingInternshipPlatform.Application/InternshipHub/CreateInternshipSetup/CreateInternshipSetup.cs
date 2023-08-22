using ProgrammingInternshipPlatform.Application.Abstractions.Handlers;
using ProgrammingInternshipPlatform.Application.Abstractions.Requests;
using ProgrammingInternshipPlatform.Application.ResultPattern;
using ProgrammingInternshipPlatform.Dal.Context;
using ProgrammingInternshipPlatform.Domain.InternshipHub.Internships.Enums;
using ProgrammingInternshipPlatform.Domain.InternshipHub.Internships.Models;
using ProgrammingInternshipPlatform.Domain.Shared.ErrorHandling.Exceptions;

namespace ProgrammingInternshipPlatform.Application.InternshipHub.CreateInternshipSetup;

public record CreateInternshipSetupCommand(int Center, int DurationInMonths, int MaxInternsToEnroll,
    DateTime ScheduledToStartOn, DateTime? EstimatedToEndOn) : IApplicationRequest<Internship>;

public class CreateInternshipSetupHandler : IApplicationHandler<CreateInternshipSetupCommand, Internship>
{
    private readonly ProgrammingInternshipPlatformDbContext _context;

    public CreateInternshipSetupHandler(ProgrammingInternshipPlatformDbContext context)
    {
        _context = context;
    }

    public async Task<HandlerResult<Internship>> Handle(CreateInternshipSetupCommand request,
        CancellationToken cancellationToken)
    {
        try
        {
            var internshipSetup = await Internship.CreateInternshipSetup(center: (Center)request.Center,
                durationInMonths: request.DurationInMonths, maxInternsToEnroll: request.MaxInternsToEnroll,
                scheduledToStartOn: request.ScheduledToStartOn, estimatedToEndOn: request.EstimatedToEndOn,
                cancellationToken);

            var createdInternship = await _context.Internships.AddAsync(internshipSetup, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return HandlerResult<Internship>.Success(createdInternship.Entity);
        }
        catch (DomainModelValidationException exception)
        {
            return HandlerResultFailureHelper.DomainValidationFailure<Internship>(exception.DomainValidationFailure!);
        }
    }
}