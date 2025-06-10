using SalesManagement.Application.Commons.Results;
using SalesManagement.Domain.Customers;

namespace SalesManagement.Application.Customers.CreateCustomer;

public interface ICreateCustomerUseCase
{
    Task<GeneralResult<Customer>> CreateCustomerAsync(CreateCustomerCommand command);
}