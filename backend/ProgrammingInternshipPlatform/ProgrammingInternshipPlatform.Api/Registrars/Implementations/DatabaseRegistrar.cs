using Microsoft.EntityFrameworkCore;
using ProgrammingInternshipPlatform.Dal.Context;

namespace ProgrammingInternshipPlatform.Api.Registrars.Implementations;

public class DatabaseRegistrar : IWebApplicationBuilderRegistrar
{
    public void RegisterServices(WebApplicationBuilder builder)
    {
        var connectionString = builder.Configuration.GetConnectionString(AppConfigurations.Constants.ConnectionString);
        builder.Services.AddDbContext<ProgrammingInternshipPlatformDbContext>(optionBuilder =>
        {
            optionBuilder.UseSqlServer(connectionString!);
        });
    }
}