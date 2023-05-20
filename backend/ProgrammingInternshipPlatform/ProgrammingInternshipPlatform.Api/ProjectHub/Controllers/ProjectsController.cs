using Microsoft.AspNetCore.Mvc;
using ProgrammingInternshipPlatform.Api.API.Controllers;
using ProgrammingInternshipPlatform.Api.Backlog.Contracts.Responses;
using ProgrammingInternshipPlatform.Application.Backlog;
using ProgrammingInternshipPlatform.Domain.ProjectHub.Projects;

namespace ProgrammingInternshipPlatform.Api.ProjectHub.Controllers;

public class ProjectsController : ApiController
{
    [HttpGet]
    [Route("{id}/board")]
    public async Task<IActionResult> GetProjectBacklogBoard(Guid id)
    {
        var projectBacklogBoardGetQuery = new GetProjectBacklogBoardQuery(new ProjectId(id));
        var handlerResult = await Mediator.Send(projectBacklogBoardGetQuery);
        if (handlerResult.IsSuccess)
        {
            var mapperBoardResponse = BoardGetDto.MapFromBoard(handlerResult.Payload!);
            return Ok(mapperBoardResponse);
        }

        return HandleApiErrorResponse(handlerResult.FailureReason); 
    }
}