using SalesManagement.Application.Commons.Requests;
using SalesManagement.Application.Commons.Results;
using SalesManagement.Domain.Customers;

namespace SalesManagement.Application.Customers.GetCustomerList;

public interface IGetCustomerListUseCase
{
    Task<PagingListResult<Customer>> GetCustomerListAsync(BaseApiListRequest request);
}