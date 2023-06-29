namespace ProgrammingInternshipPlatform.Api.Account.Contracts.Responses;

public class JwtTokenResponse
{
    public JwtTokenResponse(string token)
    {
        Token = token;
    }
    public string Token { get; }
}