using ProgrammingInternshipPlatform.Application.Abstractions.ExternalRequests.Responses;

namespace ProgrammingInternshipPlatform.Application.Abstractions.ExternalRequests;

public interface IAccountsService
{
    public Task<IEnumerable<Account>> GetAllAccounts();
}