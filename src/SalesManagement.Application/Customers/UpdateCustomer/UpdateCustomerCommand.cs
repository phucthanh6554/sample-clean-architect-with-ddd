namespace SalesManagement.Application.Customers.UpdateCustomer;

public class UpdateCustomerCommand
{
    public string Email { get; init; } = string.Empty;
    
    public string Address { get; init; } = string.Empty;
    
    public string City { get; init; } = string.Empty;
    
    public string Country { get; init; } = string.Empty;
}