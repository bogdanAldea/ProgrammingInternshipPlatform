namespace ProgrammingInternshipPlatform.Api.Registrars.Implementations;

public class CachingRegistrar : IWebApplicationBuilderRegistrar
{
    public void RegisterServices(WebApplicationBuilder builder)
    {
        builder.Services.AddMemoryCache();
    }
}