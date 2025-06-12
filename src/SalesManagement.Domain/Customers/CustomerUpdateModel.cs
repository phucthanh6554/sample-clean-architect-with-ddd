namespace SalesManagement.Domain.Customers;

public record CustomerUpdateModel
{
    public string Email { get; init; } = string.Empty;
    
    public string Address { get; init; } = string.Empty;
    
    public string City { get; init; } = string.Empty;
    
    public string Country { get; init; } = string.Empty;
}