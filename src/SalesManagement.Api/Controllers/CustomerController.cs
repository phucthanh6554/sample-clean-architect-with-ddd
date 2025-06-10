using Microsoft.AspNetCore.Mvc;
using SalesManagement.Api.Commons;
using SalesManagement.Application.Customers.CreateCustomer;

namespace SalesManagement.Api.Controllers;

[Microsoft.AspNetCore.Components.Route("api/customers")]
public class CustomerController : ApiBaseController
{
    private readonly ICreateCustomerUseCase _createCustomerUseCase;

    public CustomerController(ICreateCustomerUseCase createCustomerUseCase)
    {
        _createCustomerUseCase = createCustomerUseCase;
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] CreateCustomerCommand command)
    {
        if(!ModelState.IsValid)
            return BadRequest(ModelState);
        
        var result = await _createCustomerUseCase.CreateCustomerAsync(command);

        return ReturnResponse(result);
    }
}