using Microsoft.Graph.Models;
using ProgrammingInternshipPlatform.Application.Abstractions.GraphApi.Responses;
using ProgrammingInternshipPlatform.Domain.AccountManagement.Identifiers;

namespace ProgrammingInternshipPlatform.Application.Abstractions.GraphApi;

public interface IAccountsService
{
    public Task<Account?> GetUserAccount(AccountId accountId);
    public Task<IEnumerable<Account>> GetAllAccounts();
    public Task<IEnumerable<Account>> GetAccountsByRole(string roleId);
}