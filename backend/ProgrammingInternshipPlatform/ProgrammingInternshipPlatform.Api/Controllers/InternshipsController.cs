﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProgrammingInternshipPlatform.Api.Constants;
using ProgrammingInternshipPlatform.Api.Contracts.InternshipContracts.Requests;
using ProgrammingInternshipPlatform.Application.InternshipManagement.ExtendInternshipEndDate;
using ProgrammingInternshipPlatform.Application.InternshipManagement.GetInternshipProgramById;
using ProgrammingInternshipPlatform.Application.InternshipManagement.RescheduleInternshipStartDate;
using ProgrammingInternshipPlatform.Application.InternshipManagement.SetupNewInternshipProgram;
using ProgrammingInternshipPlatform.Domain.InternshipManagement.Identifiers;
using ProgrammingInternshipPlatform.Domain.Locations.Identifiers;

namespace ProgrammingInternshipPlatform.Api.Controllers;

public class InternshipsController : ApiController
{
    [HttpGet]
    [Route(ApiRoutes.IdRoute)]
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
            scheduledToStartOnDate: internshipPostDto.ScheduledToStartOnDate
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
    [Route(ApiRoutes.InternshipRoutes.StartDateRescheduling)]
    public async Task<IActionResult> RescheduleInternshipStartDate(Guid id,
        [FromBody] InternshipRescheduleDto rescheduleDto)
    {
        var internshipStartRescheduleCommand = new RescheduleInternshipStartDateCommand(
            new InternshipId(id), rescheduleDto.RescheduledDate);

        var handlerResult = await Mediator.Send(internshipStartRescheduleCommand);

        if (handlerResult.IsSuccess)
        {
            return NoContent();
        }

        return HandleApiErrorResponse(handlerResult.FailureReason);
    }

    [HttpPatch]
    [Route(ApiRoutes.InternshipRoutes.EndDateExtending)]
    public async Task<IActionResult> ExtendInternshipEndDate(Guid id, [FromBody] InternshipRescheduleDto rescheduleDto)
    {
        var internshipEndDateExtensionCommand =
            new ExtendInternshipEndDateCommand(new InternshipId(id), rescheduleDto.RescheduledDate);

        var handlerResult = await Mediator.Send(internshipEndDateExtensionCommand);

        if (handlerResult.IsSuccess)
        {
            return NoContent();
        }

        return HandleApiErrorResponse(handlerResult.FailureReason);
    }
}