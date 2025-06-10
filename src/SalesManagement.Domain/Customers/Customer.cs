using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SalesManagement.Domain.Customers.ValueObjects;

namespace SalesManagement.Domain.Customers;

public class Customer
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; init; }

    [Column("FirstName", TypeName = "nvarchar(255)")]
    public string FirstName { get; init; } = string.Empty;
    
    [Column("LastName", TypeName = "nvarchar(255)")]
    public string LastName { get; init; } = string.Empty;
    
    public EmailAddress Email { get; init; } = new EmailAddress();
    
    [Column("PhoneNumber", TypeName = "varchar(20)")]
    public string PhoneNumber { get; init; } = string.Empty;
    
    [Column("DateOfBirth", TypeName = "datetime")]
    public DateTime DateOfBirth { get; init; }
    
    public DeliveryAddress DeliveryAddress { get; init; } = new DeliveryAddress();

    public bool IsValid()
    {
        if(string.IsNullOrWhiteSpace(FirstName))
            return false;
        
        if(string.IsNullOrWhiteSpace(LastName))
            return false;
        
        if(!Email.IsValid())
            return false;
        
        if(!this.DeliveryAddress.IsValid())
            return false;
        
        return true;
    }
}