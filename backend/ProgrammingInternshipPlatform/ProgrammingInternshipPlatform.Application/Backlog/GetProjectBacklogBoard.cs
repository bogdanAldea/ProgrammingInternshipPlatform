using MediatR;
using Microsoft.EntityFrameworkCore;
using ProgrammingInternshipPlatform.Application.ResultPattern;
using ProgrammingInternshipPlatform.Dal.Context;
using ProgrammingInternshipPlatform.Domain.Backlog.Boards;
using ProgrammingInternshipPlatform.Domain.ProjectHub.Projects;

namespace ProgrammingInternshipPlatform.Application.Backlog;

public record GetProjectBacklogBoardQuery(ProjectId ProjectId) : IRequest<HandlerResult<Board>>;

public class GetProjectBacklogBoardHandler : IRequestHandler<GetProjectBacklogBoardQuery, HandlerResult<Board>>
{
    private readonly ProgrammingInternshipPlatformDbContext _context;

    public GetProjectBacklogBoardHandler(ProgrammingInternshipPlatformDbContext context)
    {
        _context = context;
    }
    public async Task<HandlerResult<Board>> Handle(GetProjectBacklogBoardQuery request, CancellationToken cancellationToken)
    {
        var backlogBoard = await _context.Boards
            .Where(board => board.ProjectId == request.ProjectId)
            .FirstOrDefaultAsync(cancellationToken);

        if (backlogBoard is null)
        {
            var backlogBoardNotFoundError = ApplicationError
                .NotFoundFailure(ApplicationErrorMessages.Board.BoardNotFound);
            return HandlerResult<Board>.Fail(backlogBoardNotFoundError);
        }
        
        return HandlerResult<Board>.Success(backlogBoard);
    }
}