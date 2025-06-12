using Microsoft.AspNetCore.Mvc;
using SalesManagement.Api.Commons;
using SalesManagement.Application.Commons.Requests;
using SalesManagement.Application.Customers.CreateCustomer;
using SalesManagement.Application.Customers.DeleteCustomer;
using SalesManagement.Application.Customers.GetCustomerList;
using SalesManagement.Application.Customers.UpdateCustomer;

namespace SalesManagement.Api.Controllers;

[Route("api/customers")]
public class CustomerController : ApiBaseController
{
    private readonly ICreateCustomerUseCase _createCustomerUseCase;
    private readonly IGetCustomerListUseCase _getCustomerListUseCase;
    private readonly IUpdateCustomerUseCase _updateCustomerUseCase;
    private readonly IDeleteCustomerUseCase _deleteCustomerUseCase;

    public CustomerController(ICreateCustomerUseCase createCustomerUseCase, 
        IGetCustomerListUseCase getCustomerListUseCase, 
        IUpdateCustomerUseCase updateCustomerUseCase,
        IDeleteCustomerUseCase deleteCustomerUseCase)
    {
        _createCustomerUseCase = createCustomerUseCase;
        _getCustomerListUseCase = getCustomerListUseCase;
        _updateCustomerUseCase = updateCustomerUseCase;
        _deleteCustomerUseCase = deleteCustomerUseCase;
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

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateCustomerAsync([FromRoute] int id, [FromBody] UpdateCustomerCommand command)
    {
        var result = await _updateCustomerUseCase.UpdateCustomerAsync(id, command);
        return ReturnResponse(result);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteCustomerAsync([FromRoute] int id)
    {
        var result = await _deleteCustomerUseCase.DeleteCustomerAsync(id);
        return ReturnResponse(result);
    }
}