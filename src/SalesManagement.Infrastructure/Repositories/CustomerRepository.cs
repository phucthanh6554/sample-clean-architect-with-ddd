using FilterExpression.Extension;
using Microsoft.EntityFrameworkCore;
using SalesManagement.Domain.Commons;
using SalesManagement.Domain.Customers;

namespace SalesManagement.Infrastructure.Repositories;

public class CustomerRepository : ICustomerRepository
{
    private readonly SalesManagementDbContext _context;

    public CustomerRepository(SalesManagementDbContext context)
    {
        _context = context;
    }

    public async Task<Customer?> GetCustomerByIdAsync(int customerId)
    {
        if (customerId == 0)
            return null;
        
        var customer = await _context.Customers.FindAsync(customerId);
        
        return customer;
    }

    public async Task<Customer?> GetCustomerByEmailAsync(string email)
    {
        if(string.IsNullOrEmpty(email))
            return null;

        var customer = await _context.Customers
            .Where(x => x.Email.Value == email)
            .FirstOrDefaultAsync();
        
        return customer;
    }

    public async Task<PagedResult<Customer>> GetCustomersAsync(string filterExpression, int pageSize, int page)
    {
        var query = _context.Customers.Filter(filterExpression);

        var count = await query.CountAsync();
        
        var customers = await query
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return new PagedResult<Customer>(count, customers);
    }

    public async Task<Customer?> CreateCustomerAsync(Customer customer)
    {
        _context.Customers.Add(customer);
        await _context.SaveChangesAsync();
        return customer;
    }

    public async Task<Customer?> UpdateCustomerAsync(Customer updateCustomerModel)
    {
        if(updateCustomerModel.Id == 0)
            return null;
        
        var existedCustomer = await _context.Customers.FindAsync(updateCustomerModel.Id);
        
        if (existedCustomer == null)
            return null;
        
        existedCustomer.Email.Value = updateCustomerModel.Email.Value;
        existedCustomer.DeliveryAddress.Address = updateCustomerModel.DeliveryAddress.Address;
        existedCustomer.DeliveryAddress.City = updateCustomerModel.DeliveryAddress.City;
        existedCustomer.DeliveryAddress.Country = updateCustomerModel.DeliveryAddress.Country;
        
        _context.Customers.Update(existedCustomer);
        await _context.SaveChangesAsync();
        return updateCustomerModel;
    }

    public async Task<bool> DeleteCustomerAsync(int customerId)
    {
        if (customerId == 0)
            return false;
        
        var customer = await _context.Customers.FindAsync(customerId);
        
        if (customer == null)
            return false;
        
        _context.Customers.Remove(customer);
        return await _context.SaveChangesAsync() > 0;
    }
}