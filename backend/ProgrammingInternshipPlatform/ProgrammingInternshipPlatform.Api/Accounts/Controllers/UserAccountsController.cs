using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProgrammingInternshipPlatform.Api.Accounts.Contracts.Requests;
using ProgrammingInternshipPlatform.Api.Accounts.Contracts.Responses;
using ProgrammingInternshipPlatform.Api.API.Constants;
using ProgrammingInternshipPlatform.Api.API.Controllers;
using ProgrammingInternshipPlatform.Api.API.Extensions;
using ProgrammingInternshipPlatform.Application.Account.UserAccountAuthentication;
using ProgrammingInternshipPlatform.Application.Account.UserAccountRoleAssigning;
using ProgrammingInternshipPlatform.Application.Account.ViewUserAccounts;
using ProgrammingInternshipPlatform.Domain.Account.UserAccounts;

namespace ProgrammingInternshipPlatform.Api.Accounts.Controllers;

public class UserAccountsController : ApiController
{
    [HttpGet]
    [Route(ApiRoutes.IdRoute)]
    public async Task<IActionResult> GetUserAccountById(Guid id)
    {
        var userAccountGetQuery = new GetUserAccountById(new AccountId(id));
        var handlerResult = await Mediator.Send(userAccountGetQuery);
        if (handlerResult.IsSuccess)
        {
            return Ok(handlerResult.Payload);
        }

        return HandleApiErrorResponse(handlerResult.FailureReason);
    }
    
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAllUserAccount()
    {
        var organisationId = User.GetOrganisationGuid();
        var allAccountsAtOrganisationQuery = new GetAllUserAccountsAtCompanyQuery(organisationId);
        var handlerResult = await Mediator.Send(allAccountsAtOrganisationQuery);
        if (handlerResult.IsSuccess)
        {
            return Ok(handlerResult.Payload);
        }

        return HandleApiErrorResponse(handlerResult.FailureReason);
    }

    [HttpPost]
    [Route(ApiRoutes.UserAccountRoutes.AccountRegistration)]
    public async Task<IActionResult> SignupAsAdministrator([FromBody] AdminAccountRegistration adminAccountRegistration)
    {
        var userAccountRegistrationCommand = new RegisterAdministratorAccountWithRolesCommand(
            FirstName: adminAccountRegistration.FirstName,
            LastName: adminAccountRegistration.LastName, Email: adminAccountRegistration.Email,
            Password: adminAccountRegistration.Password, PictureUrl: adminAccountRegistration.PictureUrl,
            Roles: adminAccountRegistration.Roles);

        var handlerResult = await Mediator.Send(userAccountRegistrationCommand);
        if (handlerResult.IsSuccess)
        {
            var userAccountResponse = UserAccountDetails.MapFromUserAccount(handlerResult.Payload!);
            return CreatedAtAction(nameof(GetUserAccountById), new { userAccountResponse.Id },
                userAccountResponse);
        }

        return HandleApiErrorResponse(handlerResult.FailureReason);
    }

    [HttpPost]
    public async Task<IActionResult> RegisterNewMemberAccount(
        [FromBody] MemberAccountRegistration memberAccountRegistration)
    {
        var memberAccountRegistrationCommand = new RegisterMemberUserWithRolesCommand(
            FirstName: memberAccountRegistration.FirstName,
            LastName: memberAccountRegistration.LastName,
            Email: memberAccountRegistration.Email,
            CompanyId: memberAccountRegistration.CompanyId,
            Roles: memberAccountRegistration.Roles);

        var handlerResult = await Mediator.Send(memberAccountRegistrationCommand);
        if (handlerResult.IsSuccess)
        {
            return Ok(handlerResult.Payload);
        }

        return HandleApiErrorResponse(handlerResult.FailureReason);
    }

    [HttpPost]
    [Route(ApiRoutes.UserAccountRoutes.AccountAuthentication)]
    public async Task<IActionResult> LoginToUserAccount([FromBody] UserAccountAuthentication userAccountAuthentication)
    {
        var authenticationCommand = new LoginToAccountCommand(
            EmailAddress: userAccountAuthentication.Email,
            Password: userAccountAuthentication.Password);

        var handlerResult = await Mediator.Send(authenticationCommand);
        if (handlerResult.IsSuccess)
        {
            return Ok(new JwtTokenResponse(handlerResult.Payload!));
        }

        return HandleApiErrorResponse(handlerResult.FailureReason);
    }

    [HttpPost]
    [Authorize(Roles = "Administrator")]
    [Route(ApiRoutes.UserAccountRoutes.AccountRolesAdd)]
    public async Task<IActionResult> AssignRolesToUserAccount(Guid id, [FromBody] IReadOnlyList<RoleRequest> roleRequest)
    {
        var roles = roleRequest.Select(role => role.Name);
        var assignRolesToAccountUserCommand = new AssignRolesToUserAccountCommand(id, roles);
        var handlerResult = await Mediator.Send(assignRolesToAccountUserCommand);
        if (handlerResult.IsSuccess)
        {
            return Ok();
        }

        return HandleApiErrorResponse(handlerResult.FailureReason);
    }
    
    [HttpPost]
    [Authorize(Roles = "Administrator")]
    [Route(ApiRoutes.UserAccountRoutes.AccountRolesRemove)]
    public async Task<IActionResult> RemoveRolesFromUserAccount(Guid id, [FromBody] IReadOnlyList<RoleRequest> roleRequest)
    {
        var roles = roleRequest.Select(role => role.Name);
        var removeRolesFromAccountUserCommand = new RemoveRolesFromUserAccountCommand(id, roles);
        var handlerResult = await Mediator.Send(removeRolesFromAccountUserCommand);
        if (handlerResult.IsSuccess)
        {
            return Ok();
        }

        return HandleApiErrorResponse(handlerResult.FailureReason);
    }
}