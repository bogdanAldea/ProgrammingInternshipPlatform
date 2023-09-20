using Microsoft.EntityFrameworkCore;
using ProgrammingInternshipPlatform.Application.Abstractions.Handlers;
using ProgrammingInternshipPlatform.Application.Abstractions.Requests;
using ProgrammingInternshipPlatform.Application.ResultPattern;
using ProgrammingInternshipPlatform.Dal.Context;
using ProgrammingInternshipPlatform.Domain.InternshipHub.Internships.Identifiers;
using ProgrammingInternshipPlatform.Domain.InternshipHub.Internships.Models;

namespace ProgrammingInternshipPlatform.Application.InternshipHub.Internships.GetInternshipSetupConfiguration;

public record GetInternshipSetupConfigurationQuery(Guid InternshipId) : IApplicationRequest<Internship>;

public class GetInternshipSetupConfigurationHandler: IApplicationHandler<GetInternshipSetupConfigurationQuery, Internship>
{
    private readonly ProgrammingInternshipPlatformDbContext _context;

    public GetInternshipSetupConfigurationHandler(ProgrammingInternshipPlatformDbContext context)
    {
        _context = context;
    }
    
    public async Task<HandlerResult<Internship>> Handle(GetInternshipSetupConfigurationQuery request, CancellationToken cancellationToken)
    {
        var internshipId = new InternshipId(request.InternshipId);
        var internship = await _context.Internships
            .Where(internship => internship.Id == internshipId)
            .SingleOrDefaultAsync(cancellationToken);

        if (internship is null)
            return HandlerResultFailureHelper.NotFoundFailure<Internship>(FailureMessages.Internship
                .InternshipNotFound);
        
        return HandlerResult<Internship>.Success(internship);
    }
}