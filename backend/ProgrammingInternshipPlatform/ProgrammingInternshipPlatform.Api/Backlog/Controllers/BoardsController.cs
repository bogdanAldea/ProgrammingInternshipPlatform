using Microsoft.AspNetCore.Mvc;
using ProgrammingInternshipPlatform.Api.API.Controllers;
using ProgrammingInternshipPlatform.Api.Backlog.Contracts.Requests;
using ProgrammingInternshipPlatform.Api.Backlog.Contracts.Responses;
using ProgrammingInternshipPlatform.Application.Backlog;
using ProgrammingInternshipPlatform.Domain.InternshipManagement.Interns;
using ProgrammingInternshipPlatform.Domain.ProjectHub.Projects;

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
}