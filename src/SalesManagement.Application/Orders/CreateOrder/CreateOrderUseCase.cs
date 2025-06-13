using System.Net;
using SalesManagement.Application.Commons.Attributes;
using SalesManagement.Application.Commons.Results;
using SalesManagement.Domain.Orders;

namespace SalesManagement.Application.Orders.CreateOrder;

[UseCase]
public class CreateOrderUseCase : ICreateOrderUseCase
{
    private readonly IOrderRepository _orderRepository;

    public CreateOrderUseCase(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<GeneralResult<Order>> CreateOrderAsync(CreateOrderCommand request)
    {
        var generateOrderResult = Order.Create(request.CustomerId, request.CreatedBy);
        
        if(!generateOrderResult.IsSuccess || generateOrderResult.Entity == null)
            return new GeneralResult<Order>(HttpStatusCode.BadRequest, generateOrderResult.ErrorMessage);
        
        var order = await _orderRepository.CreateOrderAsync(generateOrderResult.Entity);

        if (order == null)
            return new GeneralResult<Order>(HttpStatusCode.InternalServerError);
        
        return new GeneralResult<Order>(order);
    }
}