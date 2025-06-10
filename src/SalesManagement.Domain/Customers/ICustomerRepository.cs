using SalesManagement.Domain.Commons;

namespace SalesManagement.Domain.Customers;

public interface ICustomerRepository
{
    Task<Customer?> GetCustomerByIdAsync(int customerId);
    
    Task<Customer?> GetCustomerByEmailAsync(string email);
    
    Task<PagedResult<Customer>> GetCustomersAsync(string filterExpression, int pageSize, int page);
    
    Task<Customer?> CreateCustomerAsync(Customer customer);
    
    Task<Customer?> UpdateCustomerAsync(Customer updateCustomerModel);
    
    Task<bool> DeleteCustomerAsync(int customerId);
}