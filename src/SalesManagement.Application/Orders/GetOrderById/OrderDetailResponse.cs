namespace SalesManagement.Application.Orders.GetOrderById;

public record OrderDetailResponse
{
    public int Id { get; set; }
    
    public string CustomerName { get; set; } = string.Empty;
    
    public string Email { get; set; } = string.Empty;
    
    public string CreatedBy { get; set; } = string.Empty;
    
    public DateTime CreatedDate { get; set; }
    
    public List<OrderItemDetailResponse> OrderItems { get; set; } = new List<OrderItemDetailResponse>(0);
}

public record OrderItemDetailResponse
{
    public int Id { get; set; }
    
    public string ProductName { get; set; } = string.Empty;
    
    public int Quantity { get; set; }
    
    public decimal Price { get; set; }
    
    public string Currency { get; set; } = string.Empty;
}