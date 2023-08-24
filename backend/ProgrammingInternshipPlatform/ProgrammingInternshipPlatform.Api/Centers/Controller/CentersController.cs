using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProgrammingInternshipPlatform.Api.API.Controllers;
using ProgrammingInternshipPlatform.Application.Centers.GetAllCenters;

namespace ProgrammingInternshipPlatform.Api.Centers.Controller;

public class CentersController : ApiController
{
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAllCenters()
    {
        var allCentersQuery = new GetAllCentersQuery();
        var result = await Mediator.Send(allCentersQuery);
        if (result.IsSuccess && result.Payload is not null)
        {
            return Ok(result.Payload);
        }

        return HandleApiErrorResponse(result.FailureReason);
    }
}