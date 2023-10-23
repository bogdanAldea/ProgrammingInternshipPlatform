using MediatR;
using ProgrammingInternshipPlatform.Api.Registrars.Abstractions;

namespace ProgrammingInternshipPlatform.Api.Registrars.Implementations;

public class MediatorRegistrar : IWebApplicationBuilderRegistrar
{
    public void RegisterServices(WebApplicationBuilder builder)
    {
        throw new NotImplementedException();
        /*builder.Services.AddMediatR(typeof());*/
    }
}