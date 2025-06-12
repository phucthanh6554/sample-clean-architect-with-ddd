using SalesManagement.Application.Commons.Results;
using SalesManagement.Domain.Customers;

namespace SalesManagement.Application.Customers.UpdateCustomer;

public interface IUpdateCustomerUseCase
{
    Task<GeneralResult<Customer>> UpdateCustomerAsync(int customerId, UpdateCustomerCommand command);
}