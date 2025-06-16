using SalesManagement.Application.Commons.Results;
using SalesManagement.Domain.Orders;

namespace SalesManagement.Application.Orders.CreateOrderItem;

public interface ICreateOrderItemUseCase
{
    Task<GeneralResult<CreateOrderItemResponse>> CreateOrderItemAsync(CreateOrderItemCommand command); 
}