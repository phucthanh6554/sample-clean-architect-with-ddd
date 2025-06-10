using System.ComponentModel.DataAnnotations;

namespace SalesManagement.Application.Customers.CreateCustomer;

public class CreateCustomerCommand
{
    [Required]
    public string FirstName { get; init; } = string.Empty;
    
    [Required]
    public string LastName { get; init; } = string.Empty;
    
    [Required]
    public string PhoneNumber { get; init; } = string.Empty;
    
    [Required]
    public DateTime? DateOfBirth { get; init; }
    
    [Required]
    public string Address { get; init; } = string.Empty;
    
    [Required]
    public string City { get; init; } = string.Empty;
    
    [Required]
    public string Country { get; init; } = string.Empty;
    
    [Required]
    [EmailAddress]
    public string Email { get; init; } = string.Empty;
}