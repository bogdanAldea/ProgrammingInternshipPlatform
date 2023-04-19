﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProgrammingInternshipPlatform.Api.Contracts.InternshipContracts.Requests;
using ProgrammingInternshipPlatform.Application.InternshipManagement.GetInternshipProgramById;
using ProgrammingInternshipPlatform.Application.InternshipManagement.RescheduleInternshipStartDate;
using ProgrammingInternshipPlatform.Application.InternshipManagement.SetupNewInternshipProgram;
using ProgrammingInternshipPlatform.Domain.Internships.Identifiers;
using ProgrammingInternshipPlatform.Domain.Locations.Identifiers;

namespace ProgrammingInternshipPlatform.Api.Controllers;

public class InternshipsController : ApiController
{
    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetInternshipProgramById(Guid id)
    {
        var internshipGetQuery = new GetInternshipProgramByIdQuery(new InternshipId(id));
        var handlerResult = await Mediator.Send(internshipGetQuery);
        if (handlerResult.IsSuccess)
        {
            return Ok(handlerResult.Payload);
        }

        return HandleApiErrorResponse(handlerResult.FailureReason);
    }

    [HttpPost]
    public async Task<IActionResult> SetUpNewInternshipProgram([FromBody] InternshipPostDto internshipPostDto,
        CancellationToken cancellationToken)
    {
        var internshipSetUpCommand = new SetupNewInternshipProgramCommand(
            locationId: new LocationId(internshipPostDto.LocationId),
            maximumInternsToEnroll: internshipPostDto.MaximumInternsToEnroll,
            durationInMonths: internshipPostDto.DurationInMonths,
            scheduledToStartOnDate: internshipPostDto.ScheduledToStartOnDate,
            scheduledToEndOnDate: internshipPostDto.ScheduledToEndOnDate
        );

        var handlerResult = await Mediator.Send(internshipSetUpCommand, cancellationToken);
        if (!handlerResult.IsSuccess)
        {
            return HandleApiErrorResponse(handlerResult.FailureReason);
        }

        return CreatedAtAction(nameof(GetInternshipProgramById), new { Id = handlerResult.Payload!.Id },
            handlerResult.Payload);
    }

    [HttpPatch]
    [Route("{id}/timeframe/start-date")]
    public async Task<IActionResult> RescheduleInternshipStartDate(Guid id,
        [FromBody] InternshipRescheduleDto internshipRescheduleDto)
    {
        var internshipStartRescheduleCommand = new RescheduleInternshipStartDateCommand(
            new InternshipId(id), internshipRescheduleDto.RescheduledStartDate);

        var handlerResult = await Mediator.Send(internshipStartRescheduleCommand);

        if (handlerResult.IsSuccess)
        {
            return NoContent();
        }

        return HandleApiErrorResponse(handlerResult.FailureReason);
    }
}