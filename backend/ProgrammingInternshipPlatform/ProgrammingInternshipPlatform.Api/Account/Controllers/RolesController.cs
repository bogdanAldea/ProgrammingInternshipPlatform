using Microsoft.AspNetCore.Mvc;
using ProgrammingInternshipPlatform.Api.Account.Contracts.Responses;
using ProgrammingInternshipPlatform.Api.API.Constants;
using ProgrammingInternshipPlatform.Api.API.Controllers;
using ProgrammingInternshipPlatform.Application.Account;

namespace ProgrammingInternshipPlatform.Api.Account.Controllers;

public class RolesController : ApiController
{
    [HttpGet]
    [Route(ApiRoutes.UserAccountRoutes.Roles.Administrator)]
    public async Task<IActionResult> GetAdministratorRole()
    {
        var administratorRoleGetQuery = new GetAdministratorRoleQuery();
        var handlerResult = await Mediator.Send(administratorRoleGetQuery);

        if (handlerResult.IsSuccess)
        {
            var mappedRoleResponse = AdministratorRoleResponse.MapFromIdentityRole(handlerResult.Payload!);
            return Ok(mappedRoleResponse);
        }

        return HandleApiErrorResponse(handlerResult.FailureReason);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllRoles()
    {
        var allRolesQuery = new GetAllRolesQuery();
        var handlerResult = await Mediator.Send(allRolesQuery);
        if (handlerResult.IsSuccess)
        {
            return Ok(handlerResult.Payload);
        }

        return HandleApiErrorResponse(handlerResult.FailureReason);
    }
}