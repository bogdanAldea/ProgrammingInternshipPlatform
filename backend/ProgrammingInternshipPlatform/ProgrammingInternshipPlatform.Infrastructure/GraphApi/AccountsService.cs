using Azure.Identity;
using Microsoft.Extensions.Options;
using Microsoft.Graph;
using Microsoft.Graph.Models;
using Microsoft.Kiota.Abstractions;
using ProgrammingInternshipPlatform.Application.Abstractions.GraphApi;
using ProgrammingInternshipPlatform.Application.Abstractions.GraphApi.Responses;
using ProgrammingInternshipPlatform.Infrastructure.GraphApi.Settings;
using AccountId = ProgrammingInternshipPlatform.Domain.AccountManagement.Identifiers.AccountId;

namespace ProgrammingInternshipPlatform.Infrastructure.GraphApi;

public class AccountsService : IAccountsService
{
    private readonly GraphServiceClient _graphServiceClient;

    public AccountsService(IOptions<GraphApiSettings> graphApiSettings)
    {
        ClientSecretCredential credential = new ClientSecretCredential(
            tenantId: graphApiSettings.Value.TenantId,
            clientId: graphApiSettings.Value.ClientId,
            clientSecret: graphApiSettings.Value.Secret);

        string[] scopes = { "https://graph.microsoft.com/.default" };
        
        _graphServiceClient = new GraphServiceClient(credential, scopes);

    }

    public async Task<Account?> GetUserAccount(AccountId accountId)
    {
        var accountIdValue = accountId.Value;
        var user =  await _graphServiceClient.Users[accountIdValue.ToString()].GetAsync();
        return user is not null ? MapUserToAccount(user) : null;
    }

    public async Task<IEnumerable<Account>> GetAllAccounts()
    {
        var userAccounts = await GetAccounts();
            if (userAccounts is not null)
            {
                if (userAccounts.Value != null)
                    return MapUsersToAccounts(userAccounts.Value);
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
        return MapUsersToAccounts(usersWithRoles);
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

    private Task<List<User>> ParseUsersForGivenRole(UserCollectionResponse users, string roleId)
    {
        if (users.Value is null) throw new NullReferenceException();
        var usersWithRoles = new List<User>();
        
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
        return Task.FromResult(usersWithRoles);
    }

    private IEnumerable<Account> MapUsersToAccounts(List<User> users)
    {
        return users.Select(user => new Account
        {
            Id = new AccountId(Guid.Parse(user.Id!)),
            DisplayName = user.DisplayName!,
            GivenName = user.GivenName!,
            Surname = user.Surname!,
            Initials = $"{user.GivenName![0]}{user.Surname![0]}",
            JobTitle = user.JobTitle!,
            Email = FormatAccountEmail(user.UserPrincipalName!),
        });
    }
    
    private Account MapUserToAccount(User user)
    {
        return new Account
        {
            Id = new AccountId(Guid.Parse(user.Id!)),
            DisplayName = user.DisplayName!,
            GivenName = user.GivenName!,
            Surname = user.Surname!,
            Initials = $"{user.GivenName![0]}{user.Surname![0]}",
            JobTitle = user.JobTitle!,
            Email = FormatAccountEmail(user.UserPrincipalName!),
        };
    }
    
    private static string FormatAccountEmail(string email)
    {
        var emailParts = email.Split('@');
        var rebuiltEmail = $"{emailParts[0]}@shine.com";
        return rebuiltEmail;
    }
}