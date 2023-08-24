using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProgrammingInternshipPlatform.Api.API.Controllers;
using ProgrammingInternshipPlatform.Application.TechnologiesStack;

namespace ProgrammingInternshipPlatform.Api.TechnologiesStack.Controllers;

public class TechnologyStackController : ApiController
{
    [HttpGet]
    /*[Authorize]*/
    public async Task<IActionResult> GetTechnologyStack()
    {
        var allTechnologyStack = new GetTechnologyStackQuery();
        var result = await Mediator.Send(allTechnologyStack);
        if (result.IsSuccess && result.Payload is not null)
        {
            return Ok(result.Payload);
        }

        return HandleApiErrorResponse(result.FailureReason);
    }
}