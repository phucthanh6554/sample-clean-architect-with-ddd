using Microsoft.EntityFrameworkCore;
using SalesManagement.Domain.Orders;
using SalesManagement.Domain.Orders.ValueObjects;
using SalesManagement.Infrastructure.Repositories;

namespace SalesManagement.Infrastructure.Test.Repositories;

public class OrderRepositoryTest
{
    private readonly List<Order> _sampleOrders = new()
    {
        new Order
        {
            Id = 1,
            CustomerId = 1,
            CreatedDate = new DateTime(2025, 1, 1),
            CreatedBy = "Phuc Nguyen",
            OrderItems = new List<OrderItem>
            {
                new OrderItem
                {
                    Id = 1,
                    OrderId = 1,
                    ProductName = "Tissot Watch",
                    Quantity = 1,
                    UnitPrice = new Money { Value = 5000, Currency = "USD" }
                }
            }
        },
        new Order
        {
            Id = 2,
            CustomerId = 2,
            CreatedDate = new DateTime(2025, 5, 15),
            CreatedBy = "Phuc Nguyen",
            OrderItems = new List<OrderItem>
            {
                new OrderItem
                {
                    Id = 3,
                    OrderId = 2,
                    ProductName = "BMW Car",
                    Quantity = 1,
                    UnitPrice = new Money { Value = 1000000, Currency = "USD" }
                },
                new OrderItem
                {
                    Id = 4,
                    OrderId = 2,
                    ProductName = "Phone",
                    Quantity = 1,
                    UnitPrice = new Money { Value = 1000, Currency = "USD" }
                }
            }
        }
    };

    [Fact]
    public async Task CreateOrder_ValidModel_Successfully()
    {
        var validOrder = new Order
        {
            CustomerId = 1,
            CreatedDate = new DateTime(2025, 1, 1),
            CreatedBy = "Phuc Nguyen",
        };

        var context = GetDbContext();

        var repository = new OrderRepository(context);
        
        var createdOrder = await repository.CreateOrderAsync(validOrder);
        
        Assert.NotNull(createdOrder);
        Assert.True(createdOrder.Id > 0);
    }

    [Fact]
    public async Task AddOrderItem_ValidModel_Successfully()
    {
        var context = GetDbContext();
        
        var order = await context.Orders
            .Include(x => x.OrderItems)
            .FirstAsync(o => o.Id == 1);
        
        var oldOrderItemCount = order.OrderItems.Count;

        var addOrderItemModel = new OrderItemAddEditModel
        {
            ProductName = "A Sample Product",
            Quantity = 5,
            Price = 999,
            Currency = "USD"
        };

        order.AddOrderItem(addOrderItemModel);
        
        var repository = new OrderRepository(context);

        var result = await repository.UpdateOrderAsync(order);
        
        Assert.NotNull(result);
        Assert.True(result.OrderItems.Count > oldOrderItemCount);
        Assert.All(result.OrderItems, item => Assert.True(item.Id > 0));
    }
    
    [Fact]
    public async Task UpdateOrderItem_ValidModel_Successfully()
    {
        var context = GetDbContext();
        
        var order = await context.Orders
            .Include(x => x.OrderItems)
            .FirstAsync(o => o.Id == 1);

        var addOrderItemModel = new OrderItemAddEditModel
        {
            ProductName = "A Sample Product",
            Quantity = 5,
            Price = 999,
            Currency = "USD"
        };

        order.UpdateOrderItem(order.OrderItems.First().Id, addOrderItemModel);
        
        var repository = new OrderRepository(context);

        var result = await repository.UpdateOrderAsync(order);
        
        Assert.NotNull(result);
        Assert.Equal(result.OrderItems.First().ProductName, addOrderItemModel.ProductName);
    }
    
    [Fact]
    public async Task RemoveOrderItem_ValidModel_Successfully()
    {
        var context = GetDbContext();

        var orderId = 2;
        
        var order = await context.Orders
            .Include(x => x.OrderItems)
            .FirstAsync(o => o.Id == orderId);

        var removeItemId = order.OrderItems.First().Id;
        
        order.RemoveOrderItem(removeItemId);
        
        var repository = new OrderRepository(context);

        await repository.UpdateOrderAsync(order);
        
        var orderAfterUpdate = await context.Orders
            .Include(x => x.OrderItems)
            .FirstAsync(o => o.Id == orderId);
        
        var isItemDeleted = orderAfterUpdate.OrderItems.Any(x => x.Id == removeItemId) == false;
        
        Assert.NotNull(orderAfterUpdate);
        Assert.True(isItemDeleted);
    }

    private SalesManagementDbContext GetDbContext()
    {
        var options = new DbContextOptionsBuilder<SalesManagementDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;
        
        var context = new SalesManagementDbContext(options);
        
        context.Database.EnsureCreated();
        
        context.Orders.AddRange(_sampleOrders);
        context.SaveChanges();
        return context;
    }
}