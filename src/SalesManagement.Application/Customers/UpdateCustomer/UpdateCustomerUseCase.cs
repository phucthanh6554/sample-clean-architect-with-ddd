using System.Net;
using AutoMapper;
using SalesManagement.Application.Commons.Attributes;
using SalesManagement.Application.Commons.Results;
using SalesManagement.Domain.Customers;

namespace SalesManagement.Application.Customers.UpdateCustomer;

[UseCase]
public class UpdateCustomerUseCase : IUpdateCustomerUseCase
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IMapper _mapper;

    public UpdateCustomerUseCase(ICustomerRepository customerRepository, IMapper mapper)
    {
        _customerRepository = customerRepository;
        _mapper = mapper;
    }

    public async Task<GeneralResult<Customer>> UpdateCustomerAsync(int customerId, UpdateCustomerCommand command)
    {
        var customer = await _customerRepository.GetCustomerByIdAsync(customerId);
        
        if(customer == null)
            return new GeneralResult<Customer>(HttpStatusCode.NotFound);
        
        var updateCustomerModel = _mapper.Map<CustomerUpdateModel>(command);
        
        var generateUpdateCustomerResult = Customer.Update(customer, updateCustomerModel);
        
        if(!generateUpdateCustomerResult.IsSuccess || generateUpdateCustomerResult.Entity == null)
            return new GeneralResult<Customer>(HttpStatusCode.BadRequest, generateUpdateCustomerResult.ErrorMessage);
        
        var updatedCustomer = await _customerRepository.UpdateCustomerAsync(generateUpdateCustomerResult.Entity);
        
        if(updatedCustomer == null)
            return new GeneralResult<Customer>(HttpStatusCode.InternalServerError);

        return new GeneralResult<Customer>(updatedCustomer);
    }
}