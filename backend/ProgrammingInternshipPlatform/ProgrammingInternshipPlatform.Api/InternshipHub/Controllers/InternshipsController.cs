using Microsoft.AspNetCore.Mvc;
using ProgrammingInternshipPlatform.Api.API.Controllers;
using ProgrammingInternshipPlatform.Api.InternshipHub.Contracts.Responses;
using ProgrammingInternshipPlatform.Application.InternshipHub.GetInternshipPrograms;

namespace ProgrammingInternshipPlatform.Api.InternshipHub.Controllers;

public class InternshipsController : ApiController
{
    [HttpGet]
    public async Task<IActionResult> GetAllInternshipPrograms()
    {
        var allInternshipsQuery = new GetInternshipProgramsQuery();
        var queryResult = await Mediator.Send(allInternshipsQuery);
        if (queryResult.IsSuccess && queryResult.Payload is not null)
        {
            var mappedResults 
                = queryResult.Payload.Select(InternshipPartialResponse.MapResource);
            return Ok(mappedResults);
        }

        return HandleApiErrorResponse(queryResult.FailureReason);
    }
}