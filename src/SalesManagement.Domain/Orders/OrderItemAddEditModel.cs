namespace SalesManagement.Domain.Orders;

public class OrderItemAddEditModel
{
    public string ProductName { get; set; } = string.Empty;
    
    public int Quantity { get; set; }
    
    public decimal Price { get; set; }
    
    public string Currency { get; set; } = string.Empty;
}