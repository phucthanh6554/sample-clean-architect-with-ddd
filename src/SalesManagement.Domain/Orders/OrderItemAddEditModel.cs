namespace SalesManagement.Domain.Orders;

public class OrderItemAddEditModel
{
    public string ProductName { get; init; } = string.Empty;
    
    public int Quantity { get; init; }
    
    public decimal Price { get; init; }
    
    public string Currency { get; init; } = string.Empty;
}