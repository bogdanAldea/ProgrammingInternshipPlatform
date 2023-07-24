using MediatR;
using Microsoft.EntityFrameworkCore;
using ProgrammingInternshipPlatform.Application.ResultPattern;
using ProgrammingInternshipPlatform.Dal.Context;
using ProgrammingInternshipPlatform.Domain.Organisation.Companies;
using ProgrammingInternshipPlatform.Domain.Organisation.Countries;

namespace ProgrammingInternshipPlatform.Application.Organisation;

public record GetAllCountriesInOrganisationQuery(Guid CompanyId) : IRequest<HandlerResult<List<Country>>>;

public class
    GetAllCountriesInOrganisationHandler : IRequestHandler<GetAllCountriesInOrganisationQuery,
        HandlerResult<List<Country>>>
{
    private readonly ProgrammingInternshipPlatformDbContext _context;

    public GetAllCountriesInOrganisationHandler(ProgrammingInternshipPlatformDbContext context)
    {
        _context = context;
    }
    
    public async Task<HandlerResult<List<Country>>> Handle(GetAllCountriesInOrganisationQuery request,
        CancellationToken cancellationToken)
    {
        var company = await GetCompanyById(request.CompanyId, cancellationToken);

        if (company is null)
        {
            return HandlerResultFailureHelper
                .NotFoundFailure<List<Country>>(ApplicationErrorMessages.Company.CompanyNotFound);
        }
        
        return HandlerResult<List<Country>>.Success(company.Countries.ToList());
    }

    private async Task<Company?> GetCompanyById(Guid companyId, CancellationToken cancellationToken)
    {
        return await _context.Companies
            .Include(company => company.Countries)
            .Where(company => company.Id == new CompanyId(companyId))
            .SingleOrDefaultAsync(cancellationToken);
    }
}