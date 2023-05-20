using MediatR;
using Microsoft.EntityFrameworkCore;
using ProgrammingInternshipPlatform.Application.ResultPattern;
using ProgrammingInternshipPlatform.Dal.Context;
using ProgrammingInternshipPlatform.Domain.Backlog.Boards;
using ProgrammingInternshipPlatform.Domain.Backlog.Stages;
using ProgrammingInternshipPlatform.Domain.Shared.Exceptions;

namespace ProgrammingInternshipPlatform.Application.Backlog;

public record AddStageToBoardCommand(BoardId BoardId, string StageTitle, int? StageOrder) : IRequest<HandlerResult<Board>>;

public class AddStageToBoardHandler : IRequestHandler<AddStageToBoardCommand, HandlerResult<Board>>
{
    private readonly ProgrammingInternshipPlatformDbContext _context;

    public AddStageToBoardHandler(ProgrammingInternshipPlatformDbContext context)
    {
        _context = context;
    }
    public async Task<HandlerResult<Board>> Handle(AddStageToBoardCommand request, CancellationToken cancellationToken)
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
            await backlogBoard.AddStage(request.StageTitle, request.StageOrder, cancellationToken);
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