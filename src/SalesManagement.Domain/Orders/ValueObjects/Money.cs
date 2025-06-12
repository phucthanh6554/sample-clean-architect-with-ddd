using System.ComponentModel.DataAnnotations.Schema;

namespace SalesManagement.Domain.Orders.ValueObjects;

public class Money
{
    [Column(TypeName = "decimal(18, 2)")]
    public decimal Value { get; set; }
    
    [Column(TypeName = "varchar(10)")]
    public string Currency { get; set; } = string.Empty;
}