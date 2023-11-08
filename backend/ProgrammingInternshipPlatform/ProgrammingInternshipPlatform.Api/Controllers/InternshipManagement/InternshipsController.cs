using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProgrammingInternshipPlatform.Api.API.Constants;
using ProgrammingInternshipPlatform.Api.API.Controllers;
using ProgrammingInternshipPlatform.Api.Controllers.InternshipManagement.Requests;
using ProgrammingInternshipPlatform.Application.InternshipManagement.GetAllInternshipsInAtOrganisation;
using ProgrammingInternshipPlatform.Application.InternshipManagement.QueryParams;
using ProgrammingInternshipPlatform.Application.InternshipManagement.ScheduleInternship;
using ProgrammingInternshipPlatform.Domain.AccountManagement.Identifiers;

namespace ProgrammingInternshipPlatform.Api.Controllers.InternshipManagement;

public class InternshipsController : ApiController
{
    [HttpGet]
    [Authorize]
    [Route(ApiRoutes.BaseIdRoute)]
    public async Task<IActionResult> GetInternshipProgram(Guid id)
    {
        return Ok();
    }

    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAllInternshipProgramsAtOrganisation([FromQuery] InternshipQueryParams queryParams)
    {
        var allInternshipsQuery = new GetAllInternshipsAtOrganisationQuery(queryParams);
        var queryResult = await Mediator.Send(allInternshipsQuery);
        return HandleApiResponse(queryResult);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> ScheduleInternship([FromBody] InternshipSchedulingRequest request)
    {
        var scheduleInternshipCommand = new ScheduleInternshipCommand(
            CoordinatorId: new AccountId(request.CoordinatorId),
            ScheduledStartDate: request.ScheduledStartDate,
            MaxInternsToEnroll: request.MaxInternsToEnroll,
            DurationInMonths: request.DurationInMonths);

        var commandResult = await Mediator.Send(scheduleInternshipCommand);
        return HandleApiResponse(commandResult, nameof(GetInternshipProgram));
    }
}