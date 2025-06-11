using Microsoft.AspNetCore.Mvc;
using SalesManagement.Api.Commons;
using SalesManagement.Application.Commons.Requests;
using SalesManagement.Application.Customers.CreateCustomer;
using SalesManagement.Application.Customers.GetCustomerList;

namespace SalesManagement.Api.Controllers;

[Route("api/customers")]
public class CustomerController : ApiBaseController
{
    private readonly ICreateCustomerUseCase _createCustomerUseCase;
    private readonly IGetCustomerListUseCase _getCustomerListUseCase;

    public CustomerController(ICreateCustomerUseCase createCustomerUseCase, 
        IGetCustomerListUseCase getCustomerListUseCase)
    {
        _createCustomerUseCase = createCustomerUseCase;
        _getCustomerListUseCase = getCustomerListUseCase;
    }

    [HttpGet]
    public async Task<IActionResult> GetCustomersAsync([FromQuery] BaseApiListRequest request)
    {
        var listResult = await _getCustomerListUseCase.GetCustomerListAsync(request);

        return ReturnResponse(listResult);
    }

    [HttpPost]
    public async Task<IActionResult> CreateCustomerAsync([FromBody] CreateCustomerCommand command)
    {
        if(!ModelState.IsValid)
            return BadRequest(ModelState);
        
        var result = await _createCustomerUseCase.CreateCustomerAsync(command);

        return ReturnResponse(result);
    }
}