using FilterExpression.Extension;
using Microsoft.EntityFrameworkCore;
using SalesManagement.Domain.Commons;
using SalesManagement.Domain.Orders;

namespace SalesManagement.Infrastructure.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly SalesManagementDbContext _context;

    public OrderRepository(SalesManagementDbContext context)
    {
        _context = context;
    }

    public async Task<Order?> GetOrderByIdAsync(int id)
    {
        var order = await _context.Orders
            .Where(x => x.Id == id)
            .Include(x => x.OrderItems)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        
        return order;
    }

    public async Task<PagedResult<Order>> GetOrdersAsync(string filterExpression, int pageSize, int page)
    {
        var query = _context.Orders.Filter(filterExpression);
        
        var count = await query.CountAsync();

        var orders = await query
            .Include(x => x.OrderItems)
            .Include(x => x.Customer)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
        
        return new PagedResult<Order>(count, orders);
    }

    public async Task<Order?> CreateOrderAsync(Order order)
    {
        _context.Orders.Add(order);
        await _context.SaveChangesAsync();
        return order;
    }

    public async Task<Order?> UpdateOrderAsync(Order order)
    {
        _context.Orders.Update(order);
        await _context.SaveChangesAsync();
        return order;
    }

    public async Task<bool> DeleteOrderAsync(int id)
    {
        var order = await _context.Orders
            .Where(x => x.Id == id)
            .FirstOrDefaultAsync();
        
        if(order == null)
            return false;
        
        _context.Orders.Remove(order);
        return await _context.SaveChangesAsync() > 0;
    }
}