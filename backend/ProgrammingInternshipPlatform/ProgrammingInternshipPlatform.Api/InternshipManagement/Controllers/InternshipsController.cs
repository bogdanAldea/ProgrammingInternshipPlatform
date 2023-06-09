using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProgrammingInternshipPlatform.Api.API.Constants;
using ProgrammingInternshipPlatform.Api.API.Controllers;
using ProgrammingInternshipPlatform.Api.InternshipManagement.Contracts.Requests;
using ProgrammingInternshipPlatform.Api.InternshipManagement.Contracts.Responses;
using ProgrammingInternshipPlatform.Application.InternshipManagement.EnrollInternToInternship;
using ProgrammingInternshipPlatform.Application.InternshipManagement.ExtendInternshipEndDate;
using ProgrammingInternshipPlatform.Application.InternshipManagement.GetInternshipProgramById;
using ProgrammingInternshipPlatform.Application.InternshipManagement.RescheduleInternshipStartDate;
using ProgrammingInternshipPlatform.Application.InternshipManagement.SetupNewInternshipProgram;
using ProgrammingInternshipPlatform.Domain.Account.UserAccounts;
using ProgrammingInternshipPlatform.Domain.InternshipManagement.Internships;
using ProgrammingInternshipPlatform.Domain.Organization.Center;
using ProgrammingInternshipPlatform.Domain.Organization.Companys;

namespace ProgrammingInternshipPlatform.Api.InternshipManagement.Controllers;

[Authorize]
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
            var internshipResponse = InternshipDetailsDto.MapFromInternship(handlerResult.Payload!);
            return Ok(internshipResponse);
        }
        return HandleApiErrorResponse(handlerResult.FailureReason);
    }

    [HttpPost]
    public async Task<IActionResult> SetUpNewInternshipProgram([FromBody] InternshipPostDto internshipPostDto,
        CancellationToken cancellationToken)
    {
        var internshipSetUpCommand = new SetupNewInternshipProgramCommand(
            CompanyId: new CompanyId(internshipPostDto.CompanyId),
            LocationId: new LocationId(internshipPostDto.LocationId),
            MaximumInternsToEnroll: internshipPostDto.MaximumInternsToEnroll,
            DurationInMonths: internshipPostDto.DurationInMonths,
            ScheduledToStartOnDate: internshipPostDto.ScheduledToStartOnDate
        );

        var handlerResult = await Mediator.Send(internshipSetUpCommand, cancellationToken);
        if (!handlerResult.IsSuccess)
        {
            return HandleApiErrorResponse(handlerResult.FailureReason);
        }

        var internshipResponse = InternshipDetailsDto.MapFromInternship(handlerResult.Payload!);
        return CreatedAtAction(nameof(GetInternshipProgramById), new { Id = internshipResponse.Id },
            internshipResponse);
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

    [HttpPatch]
    [Route(ApiRoutes.InternshipRoutes.InternshipInternsEnrollment)]
    public async Task<IActionResult> EnrollInternToInternship(Guid id, [FromBody] InternEnrollment internEnrollment)
    {
        var internEnrollmentCommand = new EnrollNewInternToInternshipCommand(
            InternshipId: new InternshipId(id),
            AccountId: new AccountId(internEnrollment.UserAccountId)
        );

        var handlerResult = await Mediator.Send(internEnrollmentCommand);
        if (handlerResult.IsSuccess)
        {
            return NoContent();
        }

        return HandleApiErrorResponse(handlerResult.FailureReason);
    }
}