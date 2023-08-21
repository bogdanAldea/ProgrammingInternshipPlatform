using ProgrammingInternshipPlatform.Application.Abstractions.GraphApi.Responses;

namespace ProgrammingInternshipPlatform.Api.Accounts.Contracts.Responses;

public class AccountResponse
{
    public Guid Id { get; private set; }
    public string DisplayName { get; private set; }
    public string GivenName { get; private set; }
    public string Surname { get; private set; }
    public string JobTitle { get; private set; }
    public string Email { get; private set; }

    public static AccountResponse MapFromAccount(Account account)
    {
        return new AccountResponse
        {
            Id = account.Id.Value,
            DisplayName = account.DisplayName,
            GivenName = account.GivenName,
            Surname = account.Surname,
            JobTitle = account.JobTitle,
            Email = account.Email,
        };
    }
}