using Microsoft.EntityFrameworkCore;
using ProgrammingInternshipPlatform.Api.Registrars.Abstractions;
using ProgrammingInternshipPlatform.Dal.Context;

namespace ProgrammingInternshipPlatform.Api.Registrars.Implementations;

public class DatabaseRegistrar : IWebApplicationBuilderRegistrar
{
    public void RegisterServices(WebApplicationBuilder builder)
    {
        var connectionString = builder.Configuration.GetConnectionString(AppConfigurations.Constants.ConnectionString);
        if (connectionString is null)
            throw new NullReferenceException("Connection string is missing");
        builder.Services.AddDbContext<ProgrammingInternshipPlatformDbContext>(optionBuilder =>
        {
            optionBuilder.UseSqlServer("Server=ROMOB41181\\SQLEXPRESS01;Database=prog-internship-platform-dev;Trusted_Connection=True;TrustServerCertificate=True;");
        });
    }
}