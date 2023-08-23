using ProgrammingInternshipPlatform.Api.AppConfigurations;
using ProgrammingInternshipPlatform.Api.Registrars.Abstractions;
using ProgrammingInternshipPlatform.Application.Abstractions.GraphApi.Settings;
using ProgrammingInternshipPlatform.Infrastructure.GraphApi.Settings;

namespace ProgrammingInternshipPlatform.Api.Registrars.Implementations;

public class OptionsRegistrar : IWebApplicationBuilderRegistrar
{
    public void RegisterServices(WebApplicationBuilder builder)
    {
        builder.Services.Configure<RoleSettings>(
            builder.Configuration.GetSection(Constants.ApplicationRoles));

        builder.Services.Configure<GraphApiSettings>(
            builder.Configuration.GetSection(Constants.AzureAd));
    }
}