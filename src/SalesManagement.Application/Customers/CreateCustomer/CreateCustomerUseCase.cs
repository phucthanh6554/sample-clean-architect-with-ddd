using System.Net;
using AutoMapper;
using SalesManagement.Application.Commons.Results;
using SalesManagement.Domain.Customers;

namespace SalesManagement.Application.Customers.CreateCustomer;

public class CreateCustomerUseCase : ICreateCustomerUseCase
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IMapper _mapper;

    public CreateCustomerUseCase(ICustomerRepository customerRepository, IMapper mapper)
    {
        _customerRepository = customerRepository;
        _mapper = mapper;
    }

    public async Task<GeneralResult<Customer>> CreateCustomerAsync(CreateCustomerCommand command)
    {
        var modelCustomer = _mapper.Map<Customer>(command);
        
        if(!modelCustomer.IsValid())
            return new GeneralResult<Customer>(HttpStatusCode.BadRequest, "Customer info is invalid");
        
        var createdCustomer = await _customerRepository.CreateCustomerAsync(modelCustomer);
        
        if(createdCustomer == null)
            return new GeneralResult<Customer>(HttpStatusCode.InternalServerError, "Customer could not be created");
        
        return new GeneralResult<Customer>(createdCustomer);
    }
}