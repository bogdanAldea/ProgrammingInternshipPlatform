using MediatR;
using Microsoft.EntityFrameworkCore;
using ProgrammingInternshipPlatform.Application.InternshipManagement.GetInternsEnrolledInInternship.Responses;
using ProgrammingInternshipPlatform.Application.ResultPattern;
using ProgrammingInternshipPlatform.Dal.Context;
using ProgrammingInternshipPlatform.Domain.InternshipManagement.Internships;

namespace ProgrammingInternshipPlatform.Application.InternshipManagement.GetInternsEnrolledInInternship;

public record GetInternsEnrolledInInternshipQuery(Guid InternshipId) : IRequest<HandlerResult<IReadOnlyList<InternInformation>>>;

public class GetInternsEnrolledInInternshipHandler : IRequestHandler<GetInternsEnrolledInInternshipQuery,
    HandlerResult<IReadOnlyList<InternInformation>>>
{
    private readonly ProgrammingInternshipPlatformDbContext _context;

    public GetInternsEnrolledInInternshipHandler(ProgrammingInternshipPlatformDbContext context)
    {
        _context = context;
    }

    public async Task<HandlerResult<IReadOnlyList<InternInformation>>> Handle(
        GetInternsEnrolledInInternshipQuery request,
        CancellationToken cancellationToken)
    {
        var x = await _context.Internships
            .Where(internship => internship.Id == new InternshipId(request.InternshipId))
            .SelectMany(i => i.Interns)
            .Join(
                _context.UserAccount,
                i => i.AccountId,
                a => a.Id,
                (i, a) => new { Intern = i, Account = a }
            )
            .Select(result => new InternInformation(
                result.Intern.Id.Value,
                result.Account.FirstName,
                result.Account.LastName,
                result.Account.PictureUrl,
                result.Account.JoiningDate
            )).ToListAsync(cancellationToken);

        if (x is null)
        {
            var internNotFoundError =
                ApplicationError.NotFoundFailure(ApplicationErrorMessages.UserAccount.UserAccountNotFound);
            return HandlerResult<IReadOnlyList<InternInformation>>.Fail(internNotFoundError);
        }

        return HandlerResult<IReadOnlyList<InternInformation>>.Success(x);
    }
}