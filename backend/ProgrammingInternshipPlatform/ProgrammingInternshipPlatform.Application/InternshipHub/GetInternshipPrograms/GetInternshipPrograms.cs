using Microsoft.EntityFrameworkCore;
using ProgrammingInternshipPlatform.Application.Abstractions.Handlers;
using ProgrammingInternshipPlatform.Application.Abstractions.Requests;
using ProgrammingInternshipPlatform.Application.ResultPattern;
using ProgrammingInternshipPlatform.Dal.Context;
using ProgrammingInternshipPlatform.Dal.InternshipHub;
using ProgrammingInternshipPlatform.Domain.InternshipHub.Internships.Models;

namespace ProgrammingInternshipPlatform.Application.InternshipHub.GetInternshipPrograms;

public record GetInternshipProgramsQuery : IApplicationCollectionRequest<Internship>;

public class GetInternshipProgramsHandler : IApplicationCollectionHandler<GetInternshipProgramsQuery, Internship>
{
    private readonly ProgrammingInternshipPlatformDbContext _context;

    public GetInternshipProgramsHandler(ProgrammingInternshipPlatformDbContext context)
    {
        _context = context;
    }
    public async Task<HandlerResult<IReadOnlyList<Internship>>> Handle(GetInternshipProgramsQuery request, CancellationToken cancellationToken)
    {
        var allInternshipPrograms = await _context.GetAllInternships().ToListAsync(cancellationToken);
        return HandlerResult<IReadOnlyList<Internship>>.Success(allInternshipPrograms);
    }
}