using Microsoft.AspNetCore.Mvc;
using SalesManagement.Api.Commons;
using SalesManagement.Application.Orders.CreateOrderItem;

namespace SalesManagement.Api.Controllers;

[Microsoft.AspNetCore.Components.Route("api/orders")]
public class OrderItemController : ApiBaseController
{
    private readonly ICreateOrderItemUseCase _createOrderItemUseCase;

    public OrderItemController(ICreateOrderItemUseCase createOrderItemUseCase)
    {
        _createOrderItemUseCase = createOrderItemUseCase;
    }

    [HttpPost("order-items")]
    public async Task<IActionResult> CreateOrderItemAsync([FromBody] CreateOrderItemCommand command)
    {
        var result = await _createOrderItemUseCase.CreateOrderItemAsync(command);

        return ReturnResponse(result);
    }
}