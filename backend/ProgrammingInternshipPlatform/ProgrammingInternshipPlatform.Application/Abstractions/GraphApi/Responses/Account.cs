using ProgrammingInternshipPlatform.Domain.AccountManagement.Identifiers;

namespace ProgrammingInternshipPlatform.Application.Abstractions.GraphApi.Responses;

public class Account
{
    public AccountId Id { get; init; }
    public string DisplayName { get; init; }
    public string GivenName { get; init; }
    public string Surname { get; init; }
    public string Initials { get; init; }
    public string JobTitle { get; init; }
    public string Email { get; init; }
}