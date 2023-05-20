﻿using MediatR;
using Microsoft.EntityFrameworkCore;
using ProgrammingInternshipPlatform.Application.ResultPattern;
using ProgrammingInternshipPlatform.Dal.Context;
using ProgrammingInternshipPlatform.Domain.Backlog.Boards;
using ProgrammingInternshipPlatform.Domain.Backlog.Stages;
using ProgrammingInternshipPlatform.Domain.ProjectHub.WorkItems;
using ProgrammingInternshipPlatform.Domain.Shared.Exceptions;

namespace ProgrammingInternshipPlatform.Application.Backlog;

public record AddCardToBoardStageCommand(BoardId BoardId, StageId StageId, WorkItemId WorkItemId) : IRequest<HandlerResult<Board>>;

public class AddCardToBoardStageHandler : IRequestHandler<AddCardToBoardStageCommand, HandlerResult<Board>>
{
    private readonly ProgrammingInternshipPlatformDbContext _context;

    public AddCardToBoardStageHandler(ProgrammingInternshipPlatformDbContext context)
    {
        _context = context;
    }
    public async Task<HandlerResult<Board>> Handle(AddCardToBoardStageCommand request, CancellationToken cancellationToken)
    {
        var backlogBoard = await _context.Boards.
            FirstOrDefaultAsync(board => board.BoardId == request.BoardId, cancellationToken);

        if (backlogBoard is null)
        {
            var backlogBoardNotFoundError = ApplicationError
                .NotFoundFailure(ApplicationErrorMessages.Board.BoardNotFound);
            return HandlerResult<Board>.Fail(backlogBoardNotFoundError);
        }

        try
        {
            await backlogBoard.AddCard(request.StageId, request.WorkItemId, cancellationToken);
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