using AutoMapper;
using SalesManagement.Application.Commons.Attributes;
using SalesManagement.Application.Commons.Requests;
using SalesManagement.Application.Commons.Results;
using SalesManagement.Domain.Customers;

namespace SalesManagement.Application.Customers.GetCustomerList;

[UseCase]
public class GetCustomerListUseCase : IGetCustomerListUseCase
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IMapper _mapper;

    public GetCustomerListUseCase(ICustomerRepository customerRepository, IMapper mapper)
    {
        _customerRepository = customerRepository;
        _mapper = mapper;
    }

    public async Task<PagingListResult<Customer>> GetCustomerListAsync(BaseApiListRequest request)
    {
        var listResult = await _customerRepository.GetCustomersAsync(request.FilterExpression, request.PageSize, request.Page);

        return new PagingListResult<Customer>(listResult.Total, listResult.Items);
    }
}