using SalesManagement.Application.Commons.Requests;
using SalesManagement.Application.Commons.Results;

namespace SalesManagement.Application.Orders.GetOrders;

public interface IGetOrderListUseCase
{
    Task<PagingListResult<OrderListResponse>> GetListOrderAsync(BaseApiListRequest request);
}