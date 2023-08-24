﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProgrammingInternshipPlatform.Api.API.Controllers;
using ProgrammingInternshipPlatform.Api.InternshipHub.Contracts.Requests;
using ProgrammingInternshipPlatform.Api.InternshipHub.Contracts.Responses;
using ProgrammingInternshipPlatform.Application.Accounts;
using ProgrammingInternshipPlatform.Application.InternshipHub.CreateInternshipSetup;
using ProgrammingInternshipPlatform.Application.InternshipHub.GetInternshipPrograms;

namespace ProgrammingInternshipPlatform.Api.InternshipHub.Controllers;

public class InternshipsController : ApiController
{
    [HttpGet]
    [Authorize]
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

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> CreateInternshipSetup([FromBody] InternshipSetupRequest request)
    {
        var internshipSetupCreateCommand = new CreateInternshipSetupCommand(
            Center: request.Center, DurationInMonths: request.DurationInMonths, CoordinatorId: request.CoordinatorId,
            MaxInternsToEnroll: request.MaxInternsToEnroll, ScheduledToStartOn: request.ScheduledToStartOn,
            EstimatedToEndOn: request.EstimatedToEndOn);

        var result = await Mediator.Send(internshipSetupCreateCommand);
        if (result.IsSuccess && result.Payload is not null)
        {
            return Ok(result.Payload.Id);
        }

        return HandleApiErrorResponse(result.FailureReason);
    }
}