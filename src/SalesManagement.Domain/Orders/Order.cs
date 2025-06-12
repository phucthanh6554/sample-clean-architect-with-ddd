using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SalesManagement.Domain.Commons;
using SalesManagement.Domain.Customers;
using SalesManagement.Domain.Orders.ValueObjects;

namespace SalesManagement.Domain.Orders;

public class Order
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    [Column(TypeName = "int")]
    public int CustomerId { get; set; }
    
    [ForeignKey("CustomerId")]
    public Customer? Customer { get; set; }
    
    [Column(TypeName = "nvarchar(255)")]
    public string CreatedBy { get; set; } = string.Empty;
    
    [Column(TypeName = "datetime")]
    public DateTime CreatedDate { get; set; }
    
    public List<OrderItem> OrderItems { get; set; } = new();

    public static CreateEntityResult<Order> Create(int customerId, string createdBy)
    {
        return Create(customerId, createdBy, DateTime.UtcNow);
    }
    
    public static CreateEntityResult<Order> Create(int customerId, string createdBy, DateTime createdDate)
    {
        if(customerId == 0)
            return new CreateEntityResult<Order>($"Customer Id is invalid");
        
        if(string.IsNullOrEmpty(createdBy))
            return new CreateEntityResult<Order>($"Created by is required");

        var order = new Order
        {
            CustomerId = customerId,
            CreatedBy = createdBy,
            CreatedDate = createdDate
        };
        
        return new CreateEntityResult<Order>(order);
    }

    public CreateEntityResult<OrderItem> AddOrderItem(OrderItemAddEditModel orderItemAddEditModel)
    {
        var isProductExisted = OrderItems.Any(x => x.ProductName == orderItemAddEditModel.ProductName);
        
        if(isProductExisted)
            return new CreateEntityResult<OrderItem>($"Product {orderItemAddEditModel.ProductName} already exists");
        
        if(orderItemAddEditModel.Quantity <= 0)
            return new CreateEntityResult<OrderItem>($"Quantity is invalid");
        
        if(orderItemAddEditModel.Price <= 0)
            return new CreateEntityResult<OrderItem>($"Price is invalid");
        
        if(string.IsNullOrEmpty(orderItemAddEditModel.Currency))
            return new CreateEntityResult<OrderItem>($"Currency is required");

        var orderItem = new OrderItem
        {
            ProductName = orderItemAddEditModel.ProductName,
            Quantity = orderItemAddEditModel.Quantity,
            OrderId = Id,
            UnitPrice = new Money
            {
                Value = orderItemAddEditModel.Price,
                Currency = orderItemAddEditModel.Currency
            }
        };
        
        OrderItems.Add(orderItem);
        return new CreateEntityResult<OrderItem>(orderItem);
    }
    
    public CreateEntityResult<OrderItem> UpdateOrderItem(int orderItemId, OrderItemAddEditModel orderItemAddEditModel)
    {
        var orderItem = OrderItems.FirstOrDefault(x => x.Id == orderItemId);
        
        if(orderItem == null)
            return new CreateEntityResult<OrderItem>($"OrderItem {orderItemId} does not exist");
        
        var isProductExisted = OrderItems
            .Any(x => x.Id != orderItemId && x.ProductName == orderItemAddEditModel.ProductName);
        
        if(isProductExisted)
            return new CreateEntityResult<OrderItem>($"Product {orderItemAddEditModel.ProductName} already exists");
        
        if(orderItemAddEditModel.Quantity <= 0)
            return new CreateEntityResult<OrderItem>($"Quantity is invalid");
        
        if(orderItemAddEditModel.Price <= 0)
            return new CreateEntityResult<OrderItem>($"Price is invalid");
        
        if(string.IsNullOrEmpty(orderItemAddEditModel.Currency))
            return new CreateEntityResult<OrderItem>($"Currency is required");
        
        orderItem.ProductName = orderItemAddEditModel.ProductName;
        orderItem.Quantity = orderItemAddEditModel.Quantity;
        orderItem.UnitPrice = new Money
        {
            Value = orderItemAddEditModel.Price,
            Currency = orderItemAddEditModel.Currency
        };
        
        return new CreateEntityResult<OrderItem>(orderItem);
    }

    public bool RemoveOrderItem(int orderItemId)
    {
        var item = OrderItems.FirstOrDefault(x => x.Id == orderItemId);
        
        if(item == null)
            return false;
        
        OrderItems.Remove(item);
        return true;
    }
}