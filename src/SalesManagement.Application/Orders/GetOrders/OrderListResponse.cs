namespace SalesManagement.Application.Orders.GetOrders;

public class OrderListResponse
{
    public int Id { get; set; }
    
    public string CustomerName { get; set; } = string.Empty;
    
    public string Email { get; set; } = string.Empty;
    
    public string CreatedBy { get; set; } = string.Empty;
    
    public DateTime CreatedDate { get; set; }
}