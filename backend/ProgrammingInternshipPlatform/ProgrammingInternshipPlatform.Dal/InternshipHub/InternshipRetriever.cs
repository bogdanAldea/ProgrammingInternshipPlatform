using ProgrammingInternshipPlatform.Dal.Context;
using ProgrammingInternshipPlatform.Domain.InternshipHub.Internships.Models;

namespace ProgrammingInternshipPlatform.Dal.InternshipHub;

public static class InternshipRetriever
{
    public static IQueryable<Internship> GetAllInternships(this ProgrammingInternshipPlatformDbContext context)
    {
        return context.Internships.AsQueryable();
    }
}