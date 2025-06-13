using Microsoft.AspNetCore.Mvc;
using SalesManagement.Api.Commons;
using SalesManagement.Application.Commons.Requests;
using SalesManagement.Application.Orders.CreateOrder;
using SalesManagement.Application.Orders.GetOrders;

namespace SalesManagement.Api.Controllers;

[Route("api/orders")]
public class OrderController : ApiBaseController
{
    private readonly IGetOrderListUseCase _getOrderListUseCase;
    private readonly ICreateOrderUseCase _createOrderUseCase;

    public OrderController(IGetOrderListUseCase getOrderListUseCase, ICreateOrderUseCase createOrderUseCase)
    {
        _getOrderListUseCase = getOrderListUseCase;
        _createOrderUseCase = createOrderUseCase;
    }

    [HttpGet]
    public async Task<IActionResult> GetOrders([FromQuery] BaseApiListRequest request)
    {
        var result = await _getOrderListUseCase.GetListOrderAsync(request);

        return ReturnResponse(result);
    }
    
    [HttpPost]
    public async Task<IActionResult> GetOrders([FromBody] CreateOrderCommand command)
    {
        var result = await _createOrderUseCase.CreateOrderAsync(command);

        return ReturnResponse(result);
    }
}