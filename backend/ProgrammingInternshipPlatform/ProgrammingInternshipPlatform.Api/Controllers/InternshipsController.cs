using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProgrammingInternshipPlatform.Api.Contracts.InternshipContracts.Requests;
using ProgrammingInternshipPlatform.Application.InternshipManagement.SetupNewInternshipProgram;
using ProgrammingInternshipPlatform.Domain.Locations.Identifiers;

namespace ProgrammingInternshipPlatform.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class InternshipsController : ControllerBase
{
    private readonly IMediator _mediator;

    public InternshipsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> SetUpNewInternshipProgram([FromBody] InternshipPostDto internshipPostDto, CancellationToken cancellationToken)
    {
        var internshipSetUpCommand = new SetupNewInternshipProgramCommand(
            locationId: new LocationId(internshipPostDto.LocationId),
            maximumInternsToEnroll: internshipPostDto.MaximumInternsToEnroll,
            durationInMonths: internshipPostDto.DurationInMonths,
            scheduledToStartOnDate: internshipPostDto.ScheduledToStartOnDate,
            scheduledToEndOnDate: internshipPostDto.ScheduledToEndOnDate
        );

        var handlerResult = await _mediator.Send(internshipSetUpCommand, cancellationToken);
        if (!handlerResult.IsSuccess)
        {
            return BadRequest(handlerResult.FailureReason);}

        return Ok(handlerResult.Payload);
    }
}