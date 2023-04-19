using MediatR;
using Microsoft.EntityFrameworkCore;
using ProgrammingInternshipPlatform.Application.ResultPattern;
using ProgrammingInternshipPlatform.Dal.Context;
using ProgrammingInternshipPlatform.Domain.InternshipManagement.Identifiers;
using ProgrammingInternshipPlatform.Domain.InternshipManagement.Models;

namespace ProgrammingInternshipPlatform.Application.InternshipManagement.GetInternshipProgramById;

public class
    GetInternshipIdProgramByIdHandler : IRequestHandler<GetInternshipProgramByIdQuery, HandlerResult<Internship>>
{
    private readonly ProgrammingInternshipPlatformDbContext _context;

    public GetInternshipIdProgramByIdHandler(ProgrammingInternshipPlatformDbContext context)
    {
        _context = context;
    }

    public async Task<HandlerResult<Internship>> Handle(GetInternshipProgramByIdQuery request,
        CancellationToken cancellationToken)
    {
        var internship = await RetrieveInternshipResource(request.Id, cancellationToken);

        if (internship is null)
        {
            return HandleResourceNotFoundError();
        }

        return HandlerResult<Internship>.Success(internship);
    }

    private async Task<Internship?> RetrieveInternshipResource(InternshipId id, CancellationToken cancellationToken)
    {
        return await _context.Internships
            .FirstOrDefaultAsync(internship => internship.Id == id, cancellationToken: cancellationToken);
    }

    private HandlerResult<Internship> HandleResourceNotFoundError()
    {
        var notFoundError =
            ApplicationError.NotFoundFailure(ApplicationErrorMessages.InternshipMessages.InternshipNotFound);
        return HandlerResult<Internship>.Fail(notFoundError);
    }
}