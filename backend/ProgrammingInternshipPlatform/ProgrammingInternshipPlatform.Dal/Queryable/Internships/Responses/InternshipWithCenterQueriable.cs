using ProgrammingInternshipPlatform.Domain.InternshipManagement.Internships;

namespace ProgrammingInternshipPlatform.Dal.Queryable.Internships.Responses;

public class InternshipWithCenterQueryable
{
    public string Center { get; set; } = null!;
    public Internship Internship { get; set; } = null!;
}