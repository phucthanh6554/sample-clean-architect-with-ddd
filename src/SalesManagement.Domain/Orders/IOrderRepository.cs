using SalesManagement.Domain.Commons;

namespace SalesManagement.Domain.Orders;

public interface IOrderRepository
{
    Task<Order?> GetOrderByIdAsync(int id);
    
    Task<PagedResult<Order>> GetOrdersAsync(string filterExpression, int pageSize, int page);
    
    Task<Order?> CreateOrderAsync(Order order);
    
    Task<Order?> UpdateOrderAsync(Order order);
    
    Task<bool> DeleteOrderAsync(int id);
}