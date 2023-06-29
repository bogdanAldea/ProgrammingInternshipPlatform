using MediatR;
using Microsoft.EntityFrameworkCore;
using ProgrammingInternshipPlatform.Application.ResultPattern;
using ProgrammingInternshipPlatform.Dal.Context;
using ProgrammingInternshipPlatform.Domain.InternshipManagement.Internships;
using ProgrammingInternshipPlatform.Domain.Organisation.Companies;

namespace ProgrammingInternshipPlatform.Application.InternshipManagement.GetInternshipsByOrganisation;

public record GetInternshipByOrganisationQuery(CompanyId CompanyId) : IRequest<HandlerResult<List<Internship>>>;

public class GetInternshipByOrganisationHandler : IRequestHandler<GetInternshipByOrganisationQuery, HandlerResult<List<Internship>>>
{
    private readonly ProgrammingInternshipPlatformDbContext _context;

    public GetInternshipByOrganisationHandler(ProgrammingInternshipPlatformDbContext context)
    {
        _context = context;
    }
    public Task<HandlerResult<List<Internship>>> Handle(GetInternshipByOrganisationQuery request, CancellationToken cancellationToken)
    {
        var internships = _context.Internships
            .Include(internship => internship.Timeframe)
            .Where(i => i.CompanyId == request.CompanyId);
        return Task.FromResult(HandlerResult<List<Internship>>.Success(internships.ToList()));
    }
}