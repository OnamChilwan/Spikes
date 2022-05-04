using MinimalApi.Entities;
using MinimalApi.Models;

namespace MinimalApi.Queries;

public class GetCustomerQuery : IGetCustomerQuery
{
    public Task<Customer> ExecuteAsync(string id)
    {
        return Task.FromResult(new Customer
        {
            Id = id,
            Name = "Foo Bar"
        });
    }
}