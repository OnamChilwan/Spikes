using MinimalApi.Definitions;

namespace MinimalApi.Extensions;

public static class EndpointDefinitionsExtension
{
    public static IServiceCollection AddEndpointDefinitions(this IServiceCollection services, params IEndpointDefinition[] definitions)
    {
        foreach (var definition in definitions)
        {
            definition.DefineServices(services);
        }

        services.AddSingleton(definitions as IReadOnlyCollection<IEndpointDefinition>);
        return services;
    }

    public static void UseDefinitionEndpoints(this WebApplication app)
    {
        var definitions = app.Services.GetRequiredService<IReadOnlyCollection<IEndpointDefinition>>();

        foreach (var definition in definitions)
        {
            definition.DefineEndpoints(app);
        }
    }
}