using ProgrammingInternshipPlatform.Application.Abstractions.GraphApi.Responses;

namespace ProgrammingInternshipPlatform.Application.Abstractions.GraphApi;

public interface IAccountsService
{
    public Task<IEnumerable<Account>> GetAllAccounts();
    public Task<IEnumerable<Account>> GetAccountsByRole(string roleId);
}