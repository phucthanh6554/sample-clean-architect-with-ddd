using System.Net;
using SalesManagement.Application.Commons.Attributes;
using SalesManagement.Application.Commons.Results;
using SalesManagement.Domain.Orders;

namespace SalesManagement.Application.Orders.CreateOrderItem;

[UseCase]
public class CreateOrderItemUseCase : ICreateOrderItemUseCase
{
    private readonly IOrderRepository _orderRepository;

    public CreateOrderItemUseCase(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<GeneralResult<CreateOrderItemResponse>> CreateOrderItemAsync(CreateOrderItemCommand command)
    {
        var order = await _orderRepository.GetOrderByIdAsync(command.OrderId);

        if (order == null)
            return new GeneralResult<CreateOrderItemResponse>(HttpStatusCode.NotFound);

        var createOrderItemResult = order.AddOrderItem(new OrderItemAddEditModel
        {
            ProductName = command.ProductName,
            Quantity = command.Quantity,
            Price = command.Price,
            Currency = command.Currency
        });

        if (!createOrderItemResult.IsSuccess || createOrderItemResult.Entity == null)
            return new GeneralResult<CreateOrderItemResponse>(HttpStatusCode.BadRequest, createOrderItemResult.ErrorMessage);
        
        var updatedOrder = await _orderRepository.UpdateOrderAsync(order);

        if (updatedOrder == null)
            return new GeneralResult<CreateOrderItemResponse>(HttpStatusCode.InternalServerError);

        var response = new CreateOrderItemResponse
        {
            Id = createOrderItemResult.Entity.Id,
            ProductName = createOrderItemResult.Entity.ProductName,
            Quantity = createOrderItemResult.Entity.Quantity,
        };
        
        return new GeneralResult<CreateOrderItemResponse>(response);
    }
}