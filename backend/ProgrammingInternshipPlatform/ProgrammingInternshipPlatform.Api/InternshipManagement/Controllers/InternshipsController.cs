using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProgrammingInternshipPlatform.Api.API.Constants;
using ProgrammingInternshipPlatform.Api.API.Controllers;
using ProgrammingInternshipPlatform.Api.API.Extensions;
using ProgrammingInternshipPlatform.Api.API.Requirements;
using ProgrammingInternshipPlatform.Api.InternshipManagement.Contracts.Requests;
using ProgrammingInternshipPlatform.Api.InternshipManagement.Contracts.Responses;
using ProgrammingInternshipPlatform.Application.InternshipManagement.EnrollInternToInternship;
using ProgrammingInternshipPlatform.Application.InternshipManagement.ExtendInternshipEndDate;
using ProgrammingInternshipPlatform.Application.InternshipManagement.GetInternsEnrolledInInternship;
using ProgrammingInternshipPlatform.Application.InternshipManagement.GetInternshipProgramById;
using ProgrammingInternshipPlatform.Application.InternshipManagement.GetInternshipsByOrganisation;
using ProgrammingInternshipPlatform.Application.InternshipManagement.GetInternshipSettings;
using ProgrammingInternshipPlatform.Application.InternshipManagement.RescheduleInternshipStartDate;
using ProgrammingInternshipPlatform.Application.InternshipManagement.SetupNewInternshipProgram;
using ProgrammingInternshipPlatform.Domain.Account.UserAccounts;
using ProgrammingInternshipPlatform.Domain.InternshipManagement.Internships;
using ProgrammingInternshipPlatform.Domain.Organisation.Centers;
using ProgrammingInternshipPlatform.Domain.Organisation.Companies;

namespace ProgrammingInternshipPlatform.Api.InternshipManagement.Controllers;

public class InternshipsController : ApiController
{
    [HttpGet]
    [Authorize(Roles = "Administrator")]
    public async Task<IActionResult> GetAllInternshipsAtOrganisation()
    {
        var organisationGuid = User.GetOrganisationGuid();
        var getAllInternshipsAtOrganisationQuery = new GetInternshipsAtOrganisationQuery(organisationGuid);
        var handlerResult = await Mediator.Send(getAllInternshipsAtOrganisationQuery);
        if (handlerResult.IsSuccess && handlerResult.Payload is not null)
        {
            var mappedInternships = handlerResult.Payload
                .Select(InternshipDetailsDto.MapFromInternship);
            return Ok(mappedInternships);
        }

        return HandleApiErrorResponse(handlerResult.FailureReason);
    }

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

    [HttpGet]
    [Route(ApiRoutes.InternshipRoutes.InternshipSettings)]
    public async Task<IActionResult> GetInternshipSettings(Guid id)
    {
        var internshipSettingsQuery = new GetInternshipSettingsQuery(id);
        var handlerResult = await Mediator.Send(internshipSettingsQuery);
        if (handlerResult.IsSuccess)
            return Ok(handlerResult.Payload);
        return HandleApiErrorResponse(handlerResult.FailureReason);
    }

    [HttpGet]
    [Route(ApiRoutes.InternshipRoutes.EnrolledInterns)]
    public async Task<IActionResult> GetInternsEnrolledInInternship(Guid id)
    {
        var enrolledInternsQuery = new GetInternsEnrolledInInternshipQuery(id);
        var handlerResult = await Mediator.Send(enrolledInternsQuery);
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
            CompanyId: new CompanyId(internshipPostDto.CompanyId),
            CenterId: new CenterId(internshipPostDto.LocationId),
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