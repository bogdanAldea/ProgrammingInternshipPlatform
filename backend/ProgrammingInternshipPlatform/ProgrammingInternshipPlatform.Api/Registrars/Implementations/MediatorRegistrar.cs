using MediatR;
using ProgrammingInternshipPlatform.Api.Registrars.Abstractions;
using ProgrammingInternshipPlatform.Application.InternshipHub.Internships.CreateInternshipSetup;

namespace ProgrammingInternshipPlatform.Api.Registrars.Implementations;

public class MediatorRegistrar : IWebApplicationBuilderRegistrar
{
    public void RegisterServices(WebApplicationBuilder builder)
    {
        builder.Services.AddMediatR(typeof(CreateInternshipSetupCommand));
    }
}