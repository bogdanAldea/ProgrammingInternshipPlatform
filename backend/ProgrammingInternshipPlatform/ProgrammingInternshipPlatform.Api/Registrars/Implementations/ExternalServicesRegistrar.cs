using ProgrammingInternshipPlatform.Api.Registrars.Abstractions;
using ProgrammingInternshipPlatform.Application.Abstractions.GraphApi;
using ProgrammingInternshipPlatform.Infrastructure.Accounts;

namespace ProgrammingInternshipPlatform.Api.Registrars.Implementations;

public class ExternalServicesRegistrar : IWebApplicationBuilderRegistrar
{
    public void RegisterServices(WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IAccountsService, AccountsService>();
    }
}