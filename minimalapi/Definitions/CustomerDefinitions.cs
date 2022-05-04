using Microsoft.AspNetCore.Mvc;
using MinimalApi.Commands;
using MinimalApi.Handlers;
using MinimalApi.Models;
using MinimalApi.Queries;
using MinimalApi.Validators;

namespace MinimalApi.Definitions;

public class CustomerDefinitions : IEndpointDefinition
{
    public void DefineServices(IServiceCollection services)
    {
        services
            .AddScoped<CustomerHandler>()
            .AddScoped<IGetCustomerQuery, GetCustomerQuery>()
            .AddScoped<IAddCustomerCommand, AddCustomerCommand>();
    }

    public void DefineEndpoints(WebApplication app)
    {
        app.MapGet("/customers/{id}", GetCustomerById);
        app.MapPost("/customers", AddCustomer);
    }

    public async Task<IResult> GetCustomerById(
        string id,
        [FromServices] CustomerHandler handler)
    {
        var customer = await handler.Get(id);

        if (customer is null)
        {
            return Results.NotFound();
        }
        
        var response = Results.Ok(customer);
        return response;
    }

    public async Task<IResult> AddCustomer(
        [FromBody] CustomerRequest request, 
        [FromServices] CustomerHandler handler)
    {
        var errors = CustomerValidator.Validate(request);

        if (errors.Any())
        {
            return Results.BadRequest(errors);
        }

        var customer = await handler.CreateCustomer(request);
        return Results.Created("/some/uri", customer);
    }
}

