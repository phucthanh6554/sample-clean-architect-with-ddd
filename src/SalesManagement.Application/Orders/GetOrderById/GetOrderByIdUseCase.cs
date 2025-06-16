using System.Net;
using SalesManagement.Application.Commons.Attributes;
using SalesManagement.Application.Commons.Results;
using SalesManagement.Domain.Orders;

namespace SalesManagement.Application.Orders.GetOrderById;

[UseCase]
public class GetOrderByIdUseCase : IGetOrderByIdUseCase
{
    private readonly IOrderRepository _orderRepository;

    public GetOrderByIdUseCase(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<GeneralResult<OrderDetailResponse>> GetOrderByIdAsync(int id)
    {
        var order = await _orderRepository.GetOrderByIdAsync(id);
        
        if(order == null)
            return new GeneralResult<OrderDetailResponse>(HttpStatusCode.NotFound);

        var response = new OrderDetailResponse
        {
            Id = order.Id,
            CustomerName = order.Customer?.FirstName ?? string.Empty,
            Email = order.Customer?.Email.Value ?? string.Empty,
            CreatedBy = order.CreatedBy,
            CreatedDate = order.CreatedDate,
            OrderItems = order.OrderItems.Select(x => new OrderItemDetailResponse
            {
                Id = x.Id,
                ProductName = x.ProductName,
                Quantity = x.Quantity,
                Price = x.UnitPrice.Value,
                Currency = x.UnitPrice.Currency
            }).ToList()
        };
        
        return new GeneralResult<OrderDetailResponse>(response);
    }
}