using SalesManagement.Application.Commons.Results;
using SalesManagement.Domain.Orders;

namespace SalesManagement.Application.Orders.CreateOrder;

public interface ICreateOrderUseCase
{
    Task<GeneralResult<Order>> CreateOrderAsync(CreateOrderCommand request); 
}