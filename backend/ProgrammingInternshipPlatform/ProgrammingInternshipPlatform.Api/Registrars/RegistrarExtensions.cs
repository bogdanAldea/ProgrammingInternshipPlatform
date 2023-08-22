namespace ProgrammingInternshipPlatform.Api.Registrars;

public static class RegistrarExtensions
{
    public static void RegisterServices(this WebApplicationBuilder builder, Type scanningType)
    {
        var registrars = scanningType.Assembly.GetTypes()
            .Where(type => type.IsAssignableTo(typeof(IWebApplicationBuilderRegistrar)) && !type.IsAbstract && !type.IsInterface)
            .Select(Activator.CreateInstance)
            .Cast<IWebApplicationBuilderRegistrar>();

        foreach (var registrar in registrars)
        {
            registrar.RegisterServices(builder);
        }
    }
}