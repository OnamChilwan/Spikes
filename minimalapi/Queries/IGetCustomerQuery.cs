using MinimalApi.Models;

namespace MinimalApi.Queries;

public interface IGetCustomerQuery
{
    Task<Customer> ExecuteAsync(string id);
}