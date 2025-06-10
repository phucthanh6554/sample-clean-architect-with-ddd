using System.ComponentModel.DataAnnotations.Schema;

namespace SalesManagement.Domain.Customers.ValueObjects;

public class DeliveryAddress
{
    [Column(TypeName = "varchar(255)")]
    public string Address { get; set; } = string.Empty;
    
    [Column(TypeName = "varchar(50)")]
    public string City { get; set; } = string.Empty;
    
    [Column(TypeName = "varchar(50)")]
    public string Country { get; set; } = string.Empty;

    public bool IsValid()
    {
        return !string.IsNullOrWhiteSpace(Address) 
               && !string.IsNullOrWhiteSpace(City) 
               && !string.IsNullOrWhiteSpace(Country);
    }
}