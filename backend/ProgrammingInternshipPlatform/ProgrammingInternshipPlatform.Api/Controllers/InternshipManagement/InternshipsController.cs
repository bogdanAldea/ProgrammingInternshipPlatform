using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProgrammingInternshipPlatform.Api.API.Controllers;
using ProgrammingInternshipPlatform.Application.InternshipManagement.GetAllInternshipsInAtOrganisation;
using ProgrammingInternshipPlatform.Application.InternshipManagement.QueryParams;

namespace ProgrammingInternshipPlatform.Api.Controllers.InternshipManagement;

public class InternshipsController : ApiController
{
    [HttpGet]
    public async Task<IActionResult> GetAllInternshipProgramsAtOrganisation([FromQuery] InternshipQueryParams queryParams)
    {
        var allInternshipsQuery = new GetAllInternshipsAtOrganisationQuery(queryParams);
        var queryResult = await Mediator.Send(allInternshipsQuery);
        return HandleApiResponse(queryResult);
    }
}