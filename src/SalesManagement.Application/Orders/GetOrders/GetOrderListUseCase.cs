using SalesManagement.Application.Commons.Attributes;
using SalesManagement.Application.Commons.Requests;
using SalesManagement.Application.Commons.Results;
using SalesManagement.Domain.Orders;

namespace SalesManagement.Application.Orders.GetOrders;

[UseCase]
public class GetOrderListUseCase : IGetOrderListUseCase
{
    private readonly IOrderRepository _orderRepository;

    public GetOrderListUseCase(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<PagingListResult<OrderListResponse>> GetListOrderAsync(BaseApiListRequest request)
    {
        var orders = await _orderRepository.GetOrdersAsync(request.FilterExpression, request.PageSize, request.Page);
        
        var orderListResponse = orders.Items
            .Select(x => new OrderListResponse
            {
                Id = x.Id,
                CustomerName = x.Customer?.FirstName ?? string.Empty,
                Email = x.Customer?.Email.Value ?? string.Empty,
                CreatedBy = x.CreatedBy,
                CreatedDate = x.CreatedDate,
            })
            .ToList();

        return new PagingListResult<OrderListResponse>(orders.Total, orderListResponse);
    }
}