using Microsoft.AspNetCore.Mvc;
using ProgrammingInternshipPlatform.Api.Account.Contracts.Requests;
using ProgrammingInternshipPlatform.Api.Account.Contracts.Responses;
using ProgrammingInternshipPlatform.Api.Controllers;
using ProgrammingInternshipPlatform.Application.Account;
using ProgrammingInternshipPlatform.Domain.Organization.Company;

namespace ProgrammingInternshipPlatform.Api.Account.Controllers;

public class UserAccountsController : ApiController
{
    [HttpPost]
    public async Task<IActionResult> RegisterUserAccount([FromBody] UserAccountRegistration userAccountRegistration)
    {
        var userAccountRegistrationCommand = new RegisterNewAccountCommand(FirstName: userAccountRegistration.FirstName,
            LastName: userAccountRegistration.LastName, Email: userAccountRegistration.Email,
            Password: userAccountRegistration.Password, PictureUrl: userAccountRegistration.PictureUrl,
            CompanyId: new CompanyId(userAccountRegistration.CompanyId));

        var handlerResult = await Mediator.Send(userAccountRegistrationCommand);
        if (handlerResult.IsSuccess)
        {
            var userAccountResponse = UserAccountDetails.MapFromUserAccount(handlerResult.Payload!);
            return Ok(userAccountResponse);
        }

        return HandleApiErrorResponse(handlerResult.FailureReason);
    }
}