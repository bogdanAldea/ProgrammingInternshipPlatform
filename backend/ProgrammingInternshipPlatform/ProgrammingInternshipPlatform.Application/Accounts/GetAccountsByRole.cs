using ProgrammingInternshipPlatform.Application.Abstractions.GraphApi;
using ProgrammingInternshipPlatform.Application.Abstractions.GraphApi.Responses;
using ProgrammingInternshipPlatform.Application.Abstractions.Handlers;
using ProgrammingInternshipPlatform.Application.Abstractions.Requests;
using ProgrammingInternshipPlatform.Application.ResultPattern;

namespace ProgrammingInternshipPlatform.Application.Accounts;

public record GetAccountsByRoleQuery(string RoleId) : IApplicationCollectionRequest<Account>;

public class GetAccountsByRoleHandler : IApplicationCollectionHandler<GetAccountsByRoleQuery, Account>
{
    private readonly IAccountsService _accountsService;

    public GetAccountsByRoleHandler(IAccountsService accountsService)
    {
        _accountsService = accountsService;
    }
    public async Task<HandlerResult<IReadOnlyList<Account>>> Handle(GetAccountsByRoleQuery request, CancellationToken cancellationToken)
    {
        var accounts = await _accountsService.GetAccountsByRole(request.RoleId);
        return HandlerResult<IReadOnlyList<Account>>.Success(accounts.ToList());
    }
}