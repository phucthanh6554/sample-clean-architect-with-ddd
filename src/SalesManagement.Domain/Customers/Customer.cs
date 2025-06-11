using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SalesManagement.Domain.Commons;
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

    public static CreateEntityResult<Customer> Create(CustomerCreationModel creationModel)
    {
        var customer = new Customer
        {
            FirstName = creationModel.FirstName,
            LastName = creationModel.LastName,
            DateOfBirth = creationModel.DateOfBirth,
            PhoneNumber = creationModel.PhoneNumber,
            Email = new EmailAddress { Value = creationModel.Email },
            DeliveryAddress = new DeliveryAddress
            {
                City = creationModel.City,
                Country = creationModel.Country,
                Address = creationModel.Address
            }
        };
        
        if(string.IsNullOrEmpty(customer.FirstName))
            return new CreateEntityResult<Customer>("First name cannot be empty");
        
        if(string.IsNullOrEmpty(customer.LastName))
            return new CreateEntityResult<Customer>("Last name cannot be empty");
        
        if(!customer.Email.IsValid())
            return new CreateEntityResult<Customer>("Invalid email address");
        
        if(!customer.DeliveryAddress.IsValid())
            return new CreateEntityResult<Customer>("Invalid delivery address");
        
        return new CreateEntityResult<Customer>(customer);
    }
}