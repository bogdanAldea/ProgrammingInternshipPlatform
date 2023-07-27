using MediatR;
using Microsoft.EntityFrameworkCore;
using ProgrammingInternshipPlatform.Application.ResultPattern;
using ProgrammingInternshipPlatform.Dal.Context;
using ProgrammingInternshipPlatform.Domain.InternshipManagement.Internships;
using ProgrammingInternshipPlatform.Domain.Organisation.Companies;

namespace ProgrammingInternshipPlatform.Application.InternshipManagement.GetInternshipsByOrganisation;

public record GetInternshipsAtOrganisationQuery(Guid CompanyId) : IRequest<HandlerResult<List<Internship>>>;

public class GetInternshipsAtOrganisationHandler : IRequestHandler<GetInternshipsAtOrganisationQuery, HandlerResult<List<Internship>>>
{
    private readonly ProgrammingInternshipPlatformDbContext _context;

    public GetInternshipsAtOrganisationHandler(ProgrammingInternshipPlatformDbContext context)
    {
        _context = context;
    }
    public Task<HandlerResult<List<Internship>>> Handle(GetInternshipsAtOrganisationQuery request, CancellationToken cancellationToken)
    {
        var internships = _context.Internships
            .Include(internship => internship.Timeframe)
            .Where(i => i.CompanyId == new CompanyId(request.CompanyId));
        return Task.FromResult(HandlerResult<List<Internship>>.Success(internships.ToList()));
    }
}