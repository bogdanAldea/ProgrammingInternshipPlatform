namespace ProgrammingInternshipPlatform.Api.Accounts.Contracts.Responses;

public class JwtTokenResponse
{
    public JwtTokenResponse(string token)
    {
        Token = token;
    }
    public string Token { get; }
}