using Microsoft.AspNetCore.Mvc;
using SalesManagement.Api.Commons;
using SalesManagement.Application.Commons.Requests;
using SalesManagement.Application.Orders.CreateOrder;
using SalesManagement.Application.Orders.GetOrderById;
using SalesManagement.Application.Orders.GetOrders;

namespace SalesManagement.Api.Controllers;

[Route("api/orders")]
public class OrderController : ApiBaseController
{
    private readonly IGetOrderListUseCase _getOrderListUseCase;
    private readonly ICreateOrderUseCase _createOrderUseCase;
    private readonly IGetOrderByIdUseCase _getOrderByIdUseCase;

    public OrderController(IGetOrderListUseCase getOrderListUseCase, 
        ICreateOrderUseCase createOrderUseCase, 
        IGetOrderByIdUseCase getOrderByIdUseCase)
    {
        _getOrderListUseCase = getOrderListUseCase;
        _createOrderUseCase = createOrderUseCase;
        _getOrderByIdUseCase = getOrderByIdUseCase;
    }

    [HttpGet]
    public async Task<IActionResult> GetOrderListAsync([FromQuery] BaseApiListRequest request)
    {
        var result = await _getOrderListUseCase.GetListOrderAsync(request);

        return ReturnResponse(result);
    }

    [HttpGet("{orderId:int}")]
    public async Task<IActionResult> GetOrderByIdAsync([FromRoute] int orderId)
    {
        var result = await _getOrderByIdUseCase.GetOrderByIdAsync(orderId);
        
        return ReturnResponse(result);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateOrderAsync([FromBody] CreateOrderCommand command)
    {
        var result = await _createOrderUseCase.CreateOrderAsync(command);

        return ReturnResponse(result);
    }
}