using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace ProgrammingInternshipPlatform.Api.Registrars.Implementations;

public class AuthenticationRegistrar : IWebApplicationBuilderRegistrar
{
    public void RegisterServices(WebApplicationBuilder builder)
    {
        builder.Services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })

            .AddJwtBearer(jwt =>
            {
                jwt.SaveToken = true;
                jwt.Audience = "3eea5a6b-cc13-4f0e-b797-b32dfade784a";
                jwt.Authority = "https://login.microsoftonline.com/94a2fec0-9f74-4b78-973c-8985b3bd36f9/v2.0";

                jwt.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidIssuer = "https://login.microsoftonline.com/94a2fec0-9f74-4b78-973c-8985b3bd36f9/v2.0",
                    ValidAudience = "3eea5a6b-cc13-4f0e-b797-b32dfade784a",
                };
            });
    }
}