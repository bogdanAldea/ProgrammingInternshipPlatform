using Azure.Identity;
using Microsoft.Graph;
using ProgrammingInternshipPlatform.Application.Abstractions.GraphApi;
using ProgrammingInternshipPlatform.Application.Abstractions.GraphApi.Responses;
using AccountId = ProgrammingInternshipPlatform.Domain.Accounts.Identifiers.AccountId;

namespace ProgrammingInternshipPlatform.Infrastructure.Accounts;

public class AccountsService : IAccountsService
{
    private readonly GraphServiceClient _graphServiceClient;

    public AccountsService()
    {
        ClientSecretCredential credential = new ClientSecretCredential(
            tenantId: "94a2fec0-9f74-4b78-973c-8985b3bd36f9",
            clientId: "3eea5a6b-cc13-4f0e-b797-b32dfade784a",
            clientSecret: "Y2O8Q~Ip7AfH4_ToI58.IG2Xgjp7wCWUUtFAQc05");

        string[] scopes = { "https://graph.microsoft.com/.default" };
        this._graphServiceClient = new GraphServiceClient(credential, scopes);

    }
    
    public async Task<IEnumerable<Account>> GetAllAccounts()
    {
        var userAccounts = await _graphServiceClient.Users.GetAsync();
            if (userAccounts is not null)
            {
                if (userAccounts.Value != null)
                    return userAccounts.Value.Select(user => new Account
                    {
                        Id = new AccountId(Guid.Parse(user.Id!)),
                        DisplayName = user.DisplayName!,
                        GivenName = user.GivenName!,
                        Surname = user.Surname!,
                        JobTitle = user.JobTitle!,
                        Email = user.UserPrincipalName!
                    });
            }

            throw new InvalidOperationException();
    }
}