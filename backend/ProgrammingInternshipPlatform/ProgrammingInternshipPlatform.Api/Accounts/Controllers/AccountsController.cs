using Microsoft.AspNetCore.Mvc;
using ProgrammingInternshipPlatform.Api.Accounts.Contracts.Responses;
using ProgrammingInternshipPlatform.Api.API.Controllers;
using ProgrammingInternshipPlatform.Application.Accounts;

namespace ProgrammingInternshipPlatform.Api.Accounts.Controllers;

public class AccountsController : ApiController
{
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
    }
}