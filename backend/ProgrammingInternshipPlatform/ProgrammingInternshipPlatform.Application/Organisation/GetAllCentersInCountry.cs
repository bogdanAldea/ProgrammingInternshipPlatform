using MediatR;
using Microsoft.EntityFrameworkCore;
using ProgrammingInternshipPlatform.Application.ResultPattern;
using ProgrammingInternshipPlatform.Dal.Context;
using ProgrammingInternshipPlatform.Domain.Organisation.Centers;
using ProgrammingInternshipPlatform.Domain.Organisation.Companies;
using ProgrammingInternshipPlatform.Domain.Organisation.Countries;

namespace ProgrammingInternshipPlatform.Application.Organisation;

public record GetAllCentersInCountryQuery(Guid CompanyId, Guid CountryId) : IRequest<HandlerResult<List<Center>>>;

public class GetAllCentersInCountryHandler : IRequestHandler<GetAllCentersInCountryQuery, HandlerResult<List<Center>>>
{
    private readonly ProgrammingInternshipPlatformDbContext _context;

    public GetAllCentersInCountryHandler(ProgrammingInternshipPlatformDbContext context)
    {
        _context = context;
    }
    
    public async Task<HandlerResult<List<Center>>> Handle(GetAllCentersInCountryQuery request, CancellationToken cancellationToken)
    {
        var company = await _context.Companies
            .Include(company => company.Countries)
            .ThenInclude(country => country.Centers)
            .Where(company => company.Id == new CompanyId(request.CompanyId))
            .SingleOrDefaultAsync(cancellationToken);

        if (company is null)
        {
            return HandlerResultFailureHelper
                .NotFoundFailure<List<Center>>(ApplicationErrorMessages.Company.CompanyNotFound);
        }

        var country = company.Countries
            .SingleOrDefault(country => country.CountryId == new CountryId(request.CountryId));

        if (country is null)
        {
            return HandlerResultFailureHelper
                .NotFoundFailure<List<Center>>(ApplicationErrorMessages.Company.CountryNotFound);
        }
        
        return HandlerResult<List<Center>>.Success(country.Centers);
    }
}