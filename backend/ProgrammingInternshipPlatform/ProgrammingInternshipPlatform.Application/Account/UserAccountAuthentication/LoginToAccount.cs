using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ProgrammingInternshipPlatform.Application.Helpers;
using ProgrammingInternshipPlatform.Application.ResultPattern;
using ProgrammingInternshipPlatform.Dal.Context;
using ProgrammingInternshipPlatform.Domain.Account.UserAccounts;

namespace ProgrammingInternshipPlatform.Application.Account.UserAccountAuthentication;

public record LoginToAccountCommand(string EmailAddress, string Password) : IRequest<HandlerResult<string>>;

public class LoginToAccountHandler : IRequestHandler<LoginToAccountCommand, HandlerResult<string>>
{
    private readonly ProgrammingInternshipPlatformDbContext _context;
    private readonly UserManager<IdentityUser> _userManager;
    private readonly JwtSettings _jwtSettings;

    public LoginToAccountHandler(ProgrammingInternshipPlatformDbContext context, UserManager<IdentityUser> userManager,
        IOptions<JwtSettings> options)
    {
        _context = context;
        _userManager = userManager;
        _jwtSettings = options.Value;
    }

    public async Task<HandlerResult<string>> Handle(LoginToAccountCommand request, CancellationToken cancellationToken)
    {
        var existingIdentity = await _userManager.FindByEmailAsync(request.EmailAddress);
        if (existingIdentity is null)
        {
            return ErrorValidationHelper.NotFoundFailure<string>(
                ApplicationErrorMessages.UserAccount.EmailNotFoundForUser);
        }

        var passwordIsValid = await _userManager.CheckPasswordAsync(existingIdentity, request.Password);
        if (!passwordIsValid)
        {
            return ErrorValidationHelper.LoginPasswordFailure<string>(
                ApplicationErrorMessages.UserAccount.PasswordNotValid);
        }

        var userAccount = await GetUserAccount(existingIdentity.Id, cancellationToken);

        if (userAccount is null)
        {
            return ErrorValidationHelper.NotFoundFailure<string>(
                ApplicationErrorMessages.UserAccount.UserAccountNotFound);
        }

        var token = await GenerateAuthenticationToken(existingIdentity, userAccount);
        return HandlerResult<string>.Success(token);
    }

    private async Task<UserAccount?> GetUserAccount(string accountId, CancellationToken cancellationToken)
    {
        return await _context.UserAccount
            .SingleOrDefaultAsync(account =>
                account.IdentityId == Guid.Parse(accountId), cancellationToken);
    }

    private async Task<string> GenerateAuthenticationToken(IdentityUser existingIdentity, UserAccount account)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var signingKey = Encoding.ASCII.GetBytes(_jwtSettings.SigningKey);

        var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Sub, existingIdentity.Email),
            new Claim(JwtRegisteredClaimNames.Email, existingIdentity.Email),
            new Claim(JwtRegisteredClaimNames.GivenName, account.FirstName),
            new Claim(JwtRegisteredClaimNames.FamilyName, account.LastName),
            new Claim(JwtRegisteredClaimNames.NameId, existingIdentity.Id),
            new Claim("account_identifier", account.Id.Value.ToString())
        };
        
        var roles = await _userManager.GetRolesAsync(existingIdentity);
        foreach (var role in roles)
        {
            claims.Add(new Claim(ClaimTypes.Role, role));
        }
        
        var tokenDescriptor = new SecurityTokenDescriptor()
        {
            Subject = new ClaimsIdentity(claims),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(signingKey),
                SecurityAlgorithms.HmacSha256Signature)
        };
        
        var tokenCreate = tokenHandler.CreateToken(tokenDescriptor);
        var token = tokenHandler.WriteToken(tokenCreate);
        return token;
    }
}