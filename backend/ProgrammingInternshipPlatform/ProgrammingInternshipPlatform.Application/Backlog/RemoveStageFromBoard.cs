using MediatR;
using Microsoft.EntityFrameworkCore;
using ProgrammingInternshipPlatform.Application.ResultPattern;
using ProgrammingInternshipPlatform.Dal.Context;
using ProgrammingInternshipPlatform.Domain.Backlog.Boards;
using ProgrammingInternshipPlatform.Domain.Backlog.Stages;
using ProgrammingInternshipPlatform.Domain.Shared.Exceptions;

namespace ProgrammingInternshipPlatform.Application.Backlog;

public record RemoveStageFromBoardCommand(BoardId BoardId, StageId StageId) : IRequest<HandlerResult<Board>>;

public class RemoveStageFromBoardHandler : IRequestHandler<RemoveStageFromBoardCommand, HandlerResult<Board>>
{
    private readonly ProgrammingInternshipPlatformDbContext _context;

    public RemoveStageFromBoardHandler(ProgrammingInternshipPlatformDbContext context)
    {
        _context = context;
    }
    public async Task<HandlerResult<Board>> Handle(RemoveStageFromBoardCommand request, CancellationToken cancellationToken)
    {
        var backlogBoard = await _context.Boards
            .Where(board => board.BoardId == request.BoardId)
            .FirstOrDefaultAsync(cancellationToken);

        if (backlogBoard is null)
        {
            var backlogBoardNotFoundError = ApplicationError
                .NotFoundFailure(ApplicationErrorMessages.Board.BoardNotFound);
            return HandlerResult<Board>.Fail(backlogBoardNotFoundError);
        }

        try
        {
            await backlogBoard.RemoveStage(request.StageId, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return HandlerResult<Board>.Success();
        }
        catch (DomainModelValidationException exception)
        {
            var domainValidationError = ApplicationError.DomainValidationFailure(exception.Message);
            return HandlerResult<Board>.Fail(domainValidationError);
        }
    }
}