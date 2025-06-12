using SalesManagement.Application.Commons.Results;

namespace SalesManagement.Application.Customers.DeleteCustomer;

public interface IDeleteCustomerUseCase
{
    Task<GeneralResult<bool>> DeleteCustomerAsync(int customerId);
}