using System.Net;
using SalesManagement.Application.Commons.Attributes;
using SalesManagement.Application.Commons.Results;
using SalesManagement.Domain.Customers;

namespace SalesManagement.Application.Customers.DeleteCustomer;

[UseCase]
public class DeleteCustomerUseCase : IDeleteCustomerUseCase
{
    private readonly ICustomerRepository _customerRepository;

    public DeleteCustomerUseCase(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<GeneralResult<bool>> DeleteCustomerAsync(int customerId)
    {
        var result = await _customerRepository.DeleteCustomerAsync(customerId);

        if (result == false)
            return new GeneralResult<bool>(HttpStatusCode.BadRequest);
        
        return new GeneralResult<bool>(result);
    }
}