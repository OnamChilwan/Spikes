using MinimalApi.Commands;
using MinimalApi.Models;
using MinimalApi.Queries;

namespace MinimalApi.Handlers;

public class CustomerHandler
{
    private readonly IGetCustomerQuery _getCustomerQuery;
    private readonly IAddCustomerCommand _addCustomerCommand;

    public CustomerHandler(
        IGetCustomerQuery getCustomerQuery,
        IAddCustomerCommand addCustomerCommand)
    {
        _getCustomerQuery = getCustomerQuery;
        _addCustomerCommand = addCustomerCommand;
    }

    public async Task<Customer> Get(string id)
    {
        return await _getCustomerQuery.ExecuteAsync(id);
    }

    public async Task<Customer> CreateCustomer(CustomerRequest request)
    {
        var id = await _addCustomerCommand.Execute(request);
        return new Customer
        {
            Id = id,
            Name = request.Forename
        };
    }
}