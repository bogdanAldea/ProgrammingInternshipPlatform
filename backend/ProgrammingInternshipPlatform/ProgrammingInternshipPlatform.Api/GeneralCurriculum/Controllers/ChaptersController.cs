using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProgrammingInternshipPlatform.Api.API.Controllers;
using ProgrammingInternshipPlatform.Api.GeneralCurriculum.Contracts.Responses;
using ProgrammingInternshipPlatform.Application.GeneralCurriculum.Chapters;

namespace ProgrammingInternshipPlatform.Api.GeneralCurriculum.Controllers;

public class ChaptersController : ApiController
{
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAllChapters()
    {
        var allChaptersQuery = new GetAllChaptersQuery();
        var queryResult = await Mediator.Send(allChaptersQuery);
        if (queryResult.IsSuccess && queryResult.Payload is not null)
        {
            var mappedChapters = 
                queryResult.Payload.Select(ChapterWithVersionServerResponse.CreateFromResource);
            return Ok(mappedChapters);
        }
        return HandleApiErrorResponse(queryResult.FailureReason);
    }
}