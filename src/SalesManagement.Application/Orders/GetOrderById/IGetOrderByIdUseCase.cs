using SalesManagement.Application.Commons.Results;

namespace SalesManagement.Application.Orders.GetOrderById;

public interface IGetOrderByIdUseCase
{
    Task<GeneralResult<OrderDetailResponse>> GetOrderByIdAsync(int id);
}