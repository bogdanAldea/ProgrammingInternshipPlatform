using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProgrammingInternshipPlatform.Api.Accounts.Contracts.Responses;
using ProgrammingInternshipPlatform.Api.API.Controllers;
using ProgrammingInternshipPlatform.Application.Accounts;

namespace ProgrammingInternshipPlatform.Api.Accounts.Controllers;


public class AccountsController : ApiController
{
    /*[Authorize]
    [HttpGet]
    public async Task<IActionResult> GetAllAccounts()
    {
        var allAccountsQuery = new GetAllAccountsQuery();
        var result = await Mediator.Send(allAccountsQuery);
        if (result.IsSuccess && result.Payload is not null)
        {
            var mappedAccounts = result.Payload.Select(AccountResponse.MapFromAccount);
            return Ok(mappedAccounts);
        }
        return HandleApiErrorResponse(result.FailureReason);
    }*/

    [HttpGet]
    public async Task<IActionResult> GetAllAccountByRole([FromQuery] string role)
    {
        var getAccountsByRoleQuery = new GetAccountsByRoleQuery(role);
        var result = await Mediator.Send(getAccountsByRoleQuery);
        if (result.IsSuccess && result.Payload is not null)
        {
            return Ok(result.Payload);
        }

        return HandleApiErrorResponse(result.FailureReason);
    }
}