using Microsoft.EntityFrameworkCore;
using ProgrammingInternshipPlatform.Dal.Context;
using ProgrammingInternshipPlatform.Dal.Queryable.Internships.Responses;
using ProgrammingInternshipPlatform.Domain.InternshipManagement.Internships;
using ProgrammingInternshipPlatform.Domain.Organisation.Companies;

namespace ProgrammingInternshipPlatform.Dal.Queryable.Internships;

public static class InternshipQueryableExtensions
{
    public static IQueryable<Internship> ForInternshipAtOrganisation(this IQueryable<Internship> queryable,
        CompanyId companyId)
    {
        return queryable
            .Include(internship => internship.Timeframe)
            .Where(internship => internship.CompanyId == companyId);
    }

    public static IQueryable<InternshipWithCenterQueryable> WithCenter(this IQueryable<Internship> queryable,
        ProgrammingInternshipPlatformDbContext context)
    {
        return queryable
            .Join(context.Companies,
                internship => internship.CompanyId,
                company => company.Id,
                (internship, company) => new
                {
                    Internship = internship,
                    Centers = company.Countries.SelectMany(country => country.Centers)
                })
            .SelectMany(
                queryResult =>
                    queryResult.Centers,
                (result, center) => 
                    new InternshipWithCenterQueryable
                    {
                        Center = center.Location,
                        Internship = result.Internship
                    });
    }
}