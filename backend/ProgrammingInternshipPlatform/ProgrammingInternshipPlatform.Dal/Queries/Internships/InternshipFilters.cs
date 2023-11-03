using ProgrammingInternshipPlatform.Domain.InternshipManagement.Internships.Enums;
using ProgrammingInternshipPlatform.Domain.InternshipManagement.Internships.Models;

namespace ProgrammingInternshipPlatform.Dal.Queries.Internships;

public static class InternshipFilters
{
    public static IQueryable<Internship> FilterByStatus(this IQueryable<Internship> queryable, int? statusParam)
    {
        if (statusParam.HasValue)
        {
            InternshipStatus status = (InternshipStatus)statusParam;
            return queryable.Where(internship => internship.InternshipStatus == status);
        }
        return queryable;
    }

    public static IQueryable<Internship> FilterByScheduledStartDate(this IQueryable<Internship> queryable,
        DateTime? scheduledStartDate)
    {
        return scheduledStartDate.HasValue
            ? queryable.Where(internship => internship.ScheduledStartDate.Date == scheduledStartDate.Value)
            : queryable;
    }

    public static IQueryable<Internship> FilterByEstimatedGraduationDate(this IQueryable<Internship> queryable,
        DateTime? estimatedGraduationDate)
    {
        return estimatedGraduationDate.HasValue
            ? queryable.Where(internship => internship.EstimatedGraduationDate.Date == estimatedGraduationDate.Value)
            : queryable;
    }

}