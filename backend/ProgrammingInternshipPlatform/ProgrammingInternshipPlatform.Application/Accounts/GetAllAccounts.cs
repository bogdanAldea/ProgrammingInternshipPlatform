using ProgrammingInternshipPlatform.Application.Abstractions.ExternalRequests;
using ProgrammingInternshipPlatform.Application.Abstractions.ExternalRequests.Responses;
using ProgrammingInternshipPlatform.Application.Abstractions.Handlers;
using ProgrammingInternshipPlatform.Application.Abstractions.Requests;
using ProgrammingInternshipPlatform.Application.ResultPattern;

namespace ProgrammingInternshipPlatform.Application.Accounts;

public record GetAllAccounts : IApplicationCollectionRequest<Account>;

public class GetAllAccountsHandler : IApplicationCollectionHandler<GetAllAccounts, Account>
{
    private readonly IAccountsService _service;

    public GetAllAccountsHandler(IAccountsService service)
    {
        _service = service;
    }
    
    public async Task<HandlerResult<IReadOnlyList<Account>>> Handle(GetAllAccounts request, CancellationToken cancellationToken)
    {
        try
        {
            var accounts = await _service.GetAllAccounts();
            return HandlerResult<IReadOnlyList<Account>>.Success(accounts.ToList());
        }
        catch (Exception exception)
        {
            return HandlerResultFailureHelper.NotFoundFailure<IReadOnlyList<Account>>(exception.Message);
        }
    }
}