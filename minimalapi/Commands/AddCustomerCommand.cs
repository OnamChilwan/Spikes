using MinimalApi.Models;

namespace MinimalApi.Commands;

public interface IAddCustomerCommand
{
    Task<string> Execute(CustomerRequest customer);
}

public class AddCustomerCommand : IAddCustomerCommand
{
    public Task<string> Execute(CustomerRequest customer)
    {
        return Task.FromResult(DateTime.Now.Ticks.ToString());
    }
}