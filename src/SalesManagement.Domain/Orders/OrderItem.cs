using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SalesManagement.Domain.Orders.ValueObjects;

namespace SalesManagement.Domain.Orders;

public class OrderItem
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Column(TypeName = "nvarchar(255)")]
    public string ProductName { get; set; } = string.Empty;
    
    [Column(TypeName = "int")]
    public int Quantity { get; set; }
    
    public Money UnitPrice { get; set; } = new Money();
    
    public int OrderId { get; set; }
    
    [ForeignKey("OrderId")]
    public Order? Order { get; set; }
}