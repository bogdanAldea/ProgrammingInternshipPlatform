using Microsoft.AspNetCore.Mvc;
using ProgrammingInternshipPlatform.Api.API.Constants;
using ProgrammingInternshipPlatform.Api.API.Controllers;
using ProgrammingInternshipPlatform.Api.Backlog.Contracts.Requests;
using ProgrammingInternshipPlatform.Api.Backlog.Contracts.Responses;
using ProgrammingInternshipPlatform.Application.Backlog;
using ProgrammingInternshipPlatform.Domain.Backlog.Boards;
using ProgrammingInternshipPlatform.Domain.Backlog.Stages;
using ProgrammingInternshipPlatform.Domain.InternshipManagement.Interns;
using ProgrammingInternshipPlatform.Domain.ProjectHub.Projects;
using ProgrammingInternshipPlatform.Domain.ProjectHub.WorkItems;

namespace ProgrammingInternshipPlatform.Api.Backlog.Controllers;

public class BoardsController : ApiController
{
    [HttpPost]
    public async Task<IActionResult> CreateProjectBacklogBoard([FromBody] BoardPostDto boardPostDto)
    {
        var boardCreateCommand = new CreateBacklogBoardCommand(
            ProjectId: new ProjectId(boardPostDto.ProjectId),
            InternId: new InternId(boardPostDto.InternId));
        var handlerResult = await Mediator.Send(boardCreateCommand);
        if (handlerResult.IsSuccess)
        {
            var mappedBoardResponse = BoardGetDto.MapFromBoard(handlerResult.Payload!);
            return Ok(mappedBoardResponse);
        }
        return HandleApiErrorResponse(handlerResult.FailureReason);
    }

    [HttpPost]
    [Route(ApiRoutes.BoardRoutes.BoardStages)]
    public async Task<IActionResult> AddStageToBoard([FromBody] StageToBoardPostDto stagePostDto, Guid id)
    {
        var stageToBoardCreateCommand = new AddStageToBoardCommand(
            BoardId: new BoardId(id),
            StageTitle: stagePostDto.StageTitle,
            StageOrder: stagePostDto.StageOrder);

        var handlerResult = await Mediator.Send(stageToBoardCreateCommand);
        if (handlerResult.IsSuccess)
        {
            return NoContent();
        }

        return HandleApiErrorResponse(handlerResult.FailureReason);
    }

    [HttpPost]
    [Route(ApiRoutes.BoardRoutes.StageCards)]
    public async Task<IActionResult> AddCardToBoardStage(Guid id, Guid stageId, Guid workItemId)
    {
        var cardToBoardStageCreateCommand = new AddCardToBoardStageCommand(
            BoardId: new BoardId(id), StageId: new StageId(stageId), WorkItemId: new WorkItemId(workItemId));
        var handlerResult = await Mediator.Send(cardToBoardStageCreateCommand);
        if (handlerResult.IsSuccess)
        {
            return NoContent();
        }

        return HandleApiErrorResponse(handlerResult.FailureReason);
    }

    [HttpDelete]
    [Route(ApiRoutes.BoardRoutes.BoardStages)]
    public async Task<IActionResult> RemoveStageFromBoard(Guid id, Guid stageId)
    {
        var stageFromBoardRemovalCommand = new RemoveStageFromBoardCommand(
            BoardId: new BoardId(id), StageId: new StageId(stageId));

        var handlerResult = await Mediator.Send(stageFromBoardRemovalCommand);

        if (handlerResult.IsSuccess)
        {
            return NoContent();
        }

        return HandleApiErrorResponse(handlerResult.FailureReason);
    }
}