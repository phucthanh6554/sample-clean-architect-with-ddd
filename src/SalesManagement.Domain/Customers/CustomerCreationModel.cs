namespace SalesManagement.Domain.Customers;

public record CustomerCreationModel
{
    public string FirstName { get; init; } = string.Empty;
    
    public string LastName { get; init; } = string.Empty;
    
    public string PhoneNumber { get; init; } = string.Empty;
    
    public DateTime DateOfBirth { get; init; }
    
    public string Address { get; init; } = string.Empty;
    
    public string City { get; init; } = string.Empty;
    
    public string Country { get; init; } = string.Empty;
    
    public string Email { get; init; } = string.Empty;
}