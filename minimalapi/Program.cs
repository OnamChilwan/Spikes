using MinimalApi.Definitions;
using MinimalApi.Extensions;

namespace MinimalApi;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddEndpointDefinitions(new CustomerDefinitions());

        // Middleware for handling errors
        
        var app = builder.Build();
        app.UseDefinitionEndpoints();
        app.Run();
    }
}