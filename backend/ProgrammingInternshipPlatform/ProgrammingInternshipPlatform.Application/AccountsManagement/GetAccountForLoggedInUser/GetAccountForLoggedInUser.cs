using ProgrammingInternshipPlatform.Application.Abstractions.GraphApi;
using ProgrammingInternshipPlatform.Application.Abstractions.GraphApi.Responses;
using ProgrammingInternshipPlatform.Application.Abstractions.Handlers;
using ProgrammingInternshipPlatform.Application.Abstractions.Requests;
using ProgrammingInternshipPlatform.Application.ResultPattern;
using ProgrammingInternshipPlatform.Application.ResultPattern.FailureReason;
using ProgrammingInternshipPlatform.Domain.AccountManagement.Identifiers;

namespace ProgrammingInternshipPlatform.Application.AccountsManagement.GetAccountForLoggedInUser;

public record GetAccountForLoggedInUserQuery(AccountId AccountId) : IApplicationRequest<Account, object>;

public class GetAccountForLoggedInUserHandler : IApplicationHandler<GetAccountForLoggedInUserQuery, Account, object>
{
    private readonly IAccountsService _accountsService;

    public GetAccountForLoggedInUserHandler(IAccountsService accountsService)
    {
        _accountsService = accountsService;
    }
    
    public async Task<HandlerResult<Account, object>> Handle(GetAccountForLoggedInUserQuery request, CancellationToken cancellationToken)
    {
        var account = await _accountsService.GetUserAccount(request.AccountId);
        
        if (account is null)
            return HandlerResult<Account, object>.NotFoundFailure(FailureMessages.Accounts.AccountNotFound);
        
        return HandlerResult<Account, object>.ReadSuccessful(account);
    }
}