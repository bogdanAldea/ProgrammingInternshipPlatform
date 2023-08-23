using ProgrammingInternshipPlatform.Api.Registrars.Abstractions;

namespace ProgrammingInternshipPlatform.Api.Registrars.Implementations;

public class CorsRegistrar : IWebApplicationBuilderRegistrar
{
    public void RegisterServices(WebApplicationBuilder builder)
    {
        builder.Services.AddCors(options =>
        {
            options.AddPolicy(AppConfigurations.Constants.CorsPolicy,
                corsPolicyBuilder => corsPolicyBuilder
                    .AllowAnyMethod()
                    .AllowCredentials()
                    .SetIsOriginAllowed((host) => true)
                    .AllowAnyHeader());
        });
    }
}