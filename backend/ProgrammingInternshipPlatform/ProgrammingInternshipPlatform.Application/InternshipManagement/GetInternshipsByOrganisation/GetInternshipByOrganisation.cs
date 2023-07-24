using MediatR;
using Microsoft.EntityFrameworkCore;
using ProgrammingInternshipPlatform.Application.InternshipManagement.Responses;
using ProgrammingInternshipPlatform.Application.ResultPattern;
using ProgrammingInternshipPlatform.Dal.Context;
using ProgrammingInternshipPlatform.Dal.Queryable.Internships;
using ProgrammingInternshipPlatform.Domain.Organisation.Companies;

namespace ProgrammingInternshipPlatform.Application.InternshipManagement.GetInternshipsByOrganisation;

public record GetInternshipByOrganisationQuery(CompanyId CompanyId) : IRequest<HandlerResult<List<FullInternshipResponse>>>;

public class GetInternshipByOrganisationHandler : IRequestHandler<GetInternshipByOrganisationQuery, HandlerResult<List<FullInternshipResponse>>>
{
    private readonly ProgrammingInternshipPlatformDbContext _context;

    public GetInternshipByOrganisationHandler(ProgrammingInternshipPlatformDbContext context)
    {
        _context = context;
    }
    public async Task<HandlerResult<List<FullInternshipResponse>>> Handle(GetInternshipByOrganisationQuery request, CancellationToken cancellationToken)
    {
        var internships = await _context.Internships
            .ForInternshipAtOrganisation(request.CompanyId)
            .WithCenter(_context)
            .Select(result =>
                FullInternshipResponse.MapFromInternshipQueryResult(result.Internship, result.Center))
            .ToListAsync(cancellationToken);
        
        return HandlerResult<List<FullInternshipResponse>>.Success(internships);
    }
}