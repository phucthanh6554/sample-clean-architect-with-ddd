namespace SalesManagement.Application.Orders.CreateOrderItem;

public class CreateOrderItemResponse
{
   public int Id { get; set; }
   
   public string ProductName { get; set; } = string.Empty;
   
   public int Quantity { get; set; }
}