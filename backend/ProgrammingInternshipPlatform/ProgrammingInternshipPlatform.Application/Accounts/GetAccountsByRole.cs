using Microsoft.Extensions.Options;
using ProgrammingInternshipPlatform.Application.Abstractions.GraphApi;
using ProgrammingInternshipPlatform.Application.Abstractions.GraphApi.Responses;
using ProgrammingInternshipPlatform.Application.Abstractions.GraphApi.Settings;
using ProgrammingInternshipPlatform.Application.Abstractions.Handlers;
using ProgrammingInternshipPlatform.Application.Abstractions.Requests;
using ProgrammingInternshipPlatform.Application.ResultPattern;

namespace ProgrammingInternshipPlatform.Application.Accounts;

public record GetAccountsByRoleQuery(string RoleName) : IApplicationCollectionRequest<Account>;

public class GetAccountsByRoleHandler : IApplicationCollectionHandler<GetAccountsByRoleQuery, Account>
{
    private readonly IAccountsService _accountsService;
    private readonly IOptions<RoleSettings> _applicationRoles;

    public GetAccountsByRoleHandler(IAccountsService accountsService, IOptions<RoleSettings> applicationRoles)
    {
        _accountsService = accountsService;
        _applicationRoles = applicationRoles;
    }

    public async Task<HandlerResult<IReadOnlyList<Account>>> Handle(GetAccountsByRoleQuery request,
        CancellationToken cancellationToken)
    {
        var roleId = GetApplicationRoleId(request.RoleName);

        if (roleId == String.Empty)
        {
            return HandlerResultFailureHelper.NotFoundFailure<IReadOnlyList<Account>>(FailureMessages.Account
                .RoleNotFound);
        }

        var accounts = await _accountsService.GetAccountsByRole(roleId);
        return HandlerResult<IReadOnlyList<Account>>.Success(accounts.ToList());
    }

    private string GetApplicationRoleId(string role)
    {
        switch (role)
        {
            case "Coordinator":
                return _applicationRoles.Value.CoordinatorRoleId ?? String.Empty;
            case "Administrator":
                return _applicationRoles.Value.AdministratorRoleId ?? String.Empty;
            case "Trainer":
                return _applicationRoles.Value.TrainerRoleId ?? String.Empty;
            case "Intern":
                return _applicationRoles.Value.InternRoleId ?? String.Empty;
            default:
                return String.Empty;
        }
    }
}