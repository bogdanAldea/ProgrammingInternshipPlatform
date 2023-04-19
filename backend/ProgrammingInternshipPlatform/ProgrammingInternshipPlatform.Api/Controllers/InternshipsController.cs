using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProgrammingInternshipPlatform.Api.Contracts.InternshipContracts.Requests;
using ProgrammingInternshipPlatform.Application.InternshipManagement.SetupNewInternshipProgram;
using ProgrammingInternshipPlatform.Domain.Locations.Identifiers;

namespace ProgrammingInternshipPlatform.Api.Controllers;

public class InternshipsController : ApiController
{

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

        return Ok(handlerResult.Payload);
    }
}