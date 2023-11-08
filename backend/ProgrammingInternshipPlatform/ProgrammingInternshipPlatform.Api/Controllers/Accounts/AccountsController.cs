using Microsoft.AspNetCore.Mvc;
using ProgrammingInternshipPlatform.Api.API.Constants;
using ProgrammingInternshipPlatform.Api.API.Controllers;
using ProgrammingInternshipPlatform.Application.AccountsManagement.GetAccountForLoggedInUser;
using ProgrammingInternshipPlatform.Domain.AccountManagement.Identifiers;

namespace ProgrammingInternshipPlatform.Api.Controllers.Accounts;

public class AccountsController : ApiController
{
    [HttpGet]
    [Route(ApiRoutes.BaseIdRoute)]
    public async Task<IActionResult> GetAccountForLoggedInUser(Guid id)
    {
        var accountQuery = new GetAccountForLoggedInUserQuery(new AccountId(id));
        var queryResult = await Mediator.Send(accountQuery);
        return HandleApiResponse(queryResult);
    }
}