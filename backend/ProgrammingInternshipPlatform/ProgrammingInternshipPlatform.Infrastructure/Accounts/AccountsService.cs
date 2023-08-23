using Azure.Identity;
using Microsoft.Graph;
using Microsoft.Graph.Models;
using Microsoft.Kiota.Abstractions;
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
        var userAccounts = await GetAccounts();
            if (userAccounts is not null)
            {
                if (userAccounts.Value != null)
                    return MapUserToAccount(userAccounts.Value);
            }
            throw new NullReferenceException();
    }

    public async Task<IEnumerable<Account>> GetAccountsByRole(string roleId)
    {
        var users = await GetAccounts("appRoleAssignments");

        if (users is null)
        {
            throw new NullReferenceException();
        }

        var usersWithRoles = await ParseUsersForGivenRole(users, roleId);
        return MapUserToAccount(usersWithRoles);
    }
    
    private async Task<UserCollectionResponse?> GetAccounts(string? query = null)
    {
        if (query is null)
        {
            return await _graphServiceClient.Users.GetAsync();
        }

        return await _graphServiceClient.Users.GetAsync(request
            => request.QueryParameters.Expand = new string[] { query }
        );
    }

    private async Task<List<User>> ParseUsersForGivenRole(UserCollectionResponse users, string roleId)
    {
        if (users.Value is null) throw new NullReferenceException();
        var usersWithRoles = new List<User>();

        var nextLink = users.OdataNextLink;
        while (!string.IsNullOrEmpty(nextLink))
        {
            var nextPageRequestInformation = new RequestInformation
            {
                HttpMethod = Method.GET,
                UrlTemplate = nextLink
            };

            var nextPageResult = await _graphServiceClient.RequestAdapter.SendAsync(nextPageRequestInformation,
                (parseNode) => new UserCollectionResponse());

            if (nextPageResult is null) throw new NullReferenceException();

            foreach (var user in users.Value)
            {
                var roles = user.AppRoleAssignments;
                if (roles is null) throw new NullReferenceException();
                foreach (var role in roles)
                {
                    if (role.AppRoleId == new Guid(roleId))
                    {
                        usersWithRoles.Add(user);
                        break;
                    }
                }
            }

            nextLink = nextPageResult.OdataNextLink;
        }

        return usersWithRoles;
    }

    private IEnumerable<Account> MapUserToAccount(List<User> users)
    {
        return users.Select(user => new Account
        {
            Id = new AccountId(Guid.Parse(user.Id!)),
            DisplayName = user.DisplayName!,
            GivenName = user.GivenName!,
            Surname = user.Surname!,
            JobTitle = user.JobTitle!,
            Email = user.UserPrincipalName!,
        });
    }
}