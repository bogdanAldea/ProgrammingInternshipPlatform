using Microsoft.AspNetCore.Mvc;
using ProgrammingInternshipPlatform.Api.Account.Contracts.Requests;
using ProgrammingInternshipPlatform.Api.Account.Contracts.Responses;
using ProgrammingInternshipPlatform.Api.API.Constants;
using ProgrammingInternshipPlatform.Api.API.Controllers;
using ProgrammingInternshipPlatform.Application.Account;
using ProgrammingInternshipPlatform.Domain.Account.UserAccounts;
using ProgrammingInternshipPlatform.Domain.Organization.Companys;

namespace ProgrammingInternshipPlatform.Api.Account.Controllers;

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
            var userAccountResponse = UserAccountDetails.MapFromUserAccount(handlerResult.Payload!);
            return Ok(userAccountResponse);
        }

        return HandleApiErrorResponse(handlerResult.FailureReason);
    }

    [HttpPost]
    [Route("registration")]
    public async Task<IActionResult> RegisterUserAccount([FromBody] UserAccountRegistration userAccountRegistration)
    {
        var userAccountRegistrationCommand = new RegisterUserAccountCommand(
            FirstName: userAccountRegistration.FirstName,
            LastName: userAccountRegistration.LastName, Email: userAccountRegistration.Email,
            Password: userAccountRegistration.Password, PictureUrl: userAccountRegistration.PictureUrl,
            CompanyId: new CompanyId(userAccountRegistration.CompanyId));

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
    [Route("login")]
    public async Task<IActionResult> LoginToUserAccount([FromBody] UserAccountAuthentication userAccountAuthentication)
    {
        var authenticationCommand = new LoginToAccountCommand(
            EmailAddress: userAccountAuthentication.EmailAddress,
            Password: userAccountAuthentication.Password);

        var handlerResult = await Mediator.Send(authenticationCommand);
        if (handlerResult.IsSuccess)
        {
            return Ok(handlerResult.Payload);
        }

        return HandleApiErrorResponse(handlerResult.FailureReason);
    }
}