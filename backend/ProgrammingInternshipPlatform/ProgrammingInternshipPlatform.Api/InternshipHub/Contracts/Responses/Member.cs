using ProgrammingInternshipPlatform.Application.Abstractions.GraphApi.Responses;

namespace ProgrammingInternshipPlatform.Api.InternshipHub.Contracts.Responses;

public class Member
{
    public Guid MemberId { get; private set; }
    public string DisplayName { get; private set; } = null!;
    public string GivenName { get; private set; } = null!;
    public string Surname { get; private set; } = null!;
    public string Initials { get; private set; } = null!;
    public string JobTitle { get; private set; } = null!;
    public string Email { get; private set; } = null!;
    public string ShortenedEmail { get; private set; } = null!;
    public string? PictureUrl { get; private set; }
    public List<string>? Roles { get; private set; }

    public static Member MapFrom(Account account)
    {
        return new Member
        {
            MemberId = account.Id.Value,
            DisplayName = account.DisplayName,
            GivenName = account.GivenName,
            Surname = account.Surname,
            Initials = account.Initials,
            JobTitle = account.JobTitle,
            Email = account.Email,
            ShortenedEmail = ShortenEmail(account.Email)
        };
    }

    private static  string ShortenEmail(string originalEmail)
    {
        var atIndex = originalEmail.IndexOf("@", StringComparison.Ordinal);
        var emailPrefix = originalEmail.Substring(0, atIndex + 1);
        var newSuffix = "shine.com";
        var shortenedEmail = $"{emailPrefix}{newSuffix}";
        return shortenedEmail;
    }
}