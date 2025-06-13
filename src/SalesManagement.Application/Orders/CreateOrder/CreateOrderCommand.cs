namespace SalesManagement.Application.Orders.CreateOrder;

public class CreateOrderCommand
{
    public int CustomerId { get; set; }
    
    public string CreatedBy { get; set; } = string.Empty;
}