using System.Net;
using AutoMapper;
using SalesManagement.Application.Commons.Attributes;
using SalesManagement.Application.Commons.Results;
using SalesManagement.Domain.Customers;

namespace SalesManagement.Application.Customers.CreateCustomer;

[UseCase]
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
        var customerCreationModel = _mapper.Map<CustomerCreationModel>(command);
        
        var customerCreateResult = Customer.Create(customerCreationModel);
        
        if(!customerCreateResult.IsSuccess || customerCreateResult.Entity == null)
            return new GeneralResult<Customer>(HttpStatusCode.BadRequest, customerCreateResult.ErrorMessage);
        
        var createdCustomer = await _customerRepository.CreateCustomerAsync(customerCreateResult.Entity);
        
        if(createdCustomer == null)
            return new GeneralResult<Customer>(HttpStatusCode.InternalServerError, "Customer could not be created");
        
        return new GeneralResult<Customer>(createdCustomer);
    }
}