namespace SalesManagement.Application.Orders.CreateOrderItem;

public class CreateOrderItemCommand
{
    public int OrderId { get; set; }
    
    public string ProductName { get; init; } = string.Empty;
    
    public int Quantity { get; init; }
    
    public decimal Price { get; init; }
    
    public string Currency { get; init; } = string.Empty;
}