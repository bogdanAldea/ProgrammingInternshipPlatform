using Microsoft.EntityFrameworkCore;
using ProgrammingInternshipPlatform.Api.Registrars.Abstractions;
using ProgrammingInternshipPlatform.Dal.Context;

namespace ProgrammingInternshipPlatform.Api.Registrars.Implementations;

public class DatabaseRegistrar : IWebApplicationBuilderRegistrar
{
    public void RegisterServices(WebApplicationBuilder builder)
    {
        var connectionString = builder.Configuration.GetConnectionString(AppConfigurations.Constants.ConnectionStrings);
        builder.Services.AddDbContext<ProgrammingInternshipPlatformDbContext>(optionBuilder =>
        {
            if (connectionString is null) throw new NullReferenceException();
            optionBuilder.UseSqlServer(connectionString);
        });
    }
}