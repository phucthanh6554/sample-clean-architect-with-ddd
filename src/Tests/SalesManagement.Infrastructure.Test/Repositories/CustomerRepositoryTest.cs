using Microsoft.EntityFrameworkCore;
using SalesManagement.Domain.Customers;
using SalesManagement.Domain.Customers.ValueObjects;
using SalesManagement.Infrastructure.Repositories;

namespace SalesManagement.Infrastructure.Test.Repositories;

public class CustomerRepositoryTest
{
    private readonly List<Customer> _sampleCustomers = new List<Customer>
        {
            new Customer
            {
                Id = 1,
                FirstName = "John",
                LastName = "Doe",
                Email = new EmailAddress { Value = "john.doe@example.com" },
                PhoneNumber = "123-456-7890",
                DateOfBirth = new DateTime(1985, 1, 15),
                DeliveryAddress = new DeliveryAddress { Address = "123 Main St", City = "New York", Country = "USA" }
            },
            new Customer
            {
                Id = 2,
                FirstName = "Jane",
                LastName = "Smith",
                Email = new EmailAddress { Value = "jane.smith@example.com" },
                PhoneNumber = "098-765-4321",
                DateOfBirth = new DateTime(1990, 7, 22),
                DeliveryAddress = new DeliveryAddress { Address = "456 Oak Ave", City = "Los Angeles", Country = "USA" }
            },
            new Customer
            {
                Id = 3,
                FirstName = "Robert",
                LastName = "Johnson",
                Email = new EmailAddress { Value = "robert.j@example.com" },
                PhoneNumber = "555-123-4567",
                DateOfBirth = new DateTime(1978, 3, 10),
                DeliveryAddress = new DeliveryAddress { Address = "789 Pine Ln", City = "Chicago", Country = "USA" }
            },
            new Customer
            {
                Id = 4,
                FirstName = "Emily",
                LastName = "Brown",
                Email = new EmailAddress { Value = "emily.b@example.com" },
                PhoneNumber = "111-222-3333",
                DateOfBirth = new DateTime(1993, 11, 5),
                DeliveryAddress = new DeliveryAddress { Address = "101 Elm St", City = "Houston", Country = "USA" }
            },
            new Customer
            {
                Id = 5,
                FirstName = "Michael",
                LastName = "Davis",
                Email = new EmailAddress { Value = "michael.d@example.com" },
                PhoneNumber = "444-555-6666",
                DateOfBirth = new DateTime(1982, 9, 28),
                DeliveryAddress = new DeliveryAddress { Address = "202 Maple Dr", City = "Phoenix", Country = "USA" }
            },
            new Customer
            {
                Id = 6,
                FirstName = "Olivia",
                LastName = "Wilson",
                Email = new EmailAddress { Value = "olivia.w@example.com" },
                PhoneNumber = "777-888-9999",
                DateOfBirth = new DateTime(1995, 4, 12),
                DeliveryAddress = new DeliveryAddress { Address = "303 Birch Rd", City = "Philadelphia", Country = "USA" }
            },
            new Customer
            {
                Id = 7,
                FirstName = "William",
                LastName = "Moore",
                Email = new EmailAddress { Value = "william.m@example.com" },
                PhoneNumber = "999-888-7777",
                DateOfBirth = new DateTime(1970, 2, 1),
                DeliveryAddress = new DeliveryAddress { Address = "404 Cedar St", City = "San Antonio", Country = "USA" }
            },
            new Customer
            {
                Id = 8,
                FirstName = "Sophia",
                LastName = "Taylor",
                Email = new EmailAddress { Value = "sophia.t@example.com" },
                PhoneNumber = "222-333-4444",
                DateOfBirth = new DateTime(1989, 6, 30),
                DeliveryAddress = new DeliveryAddress { Address = "505 Dogwood Pl", City = "San Diego", Country = "USA" }
            },
            new Customer
            {
                Id = 9,
                FirstName = "James",
                LastName = "Anderson",
                Email = new EmailAddress { Value = "james.a@example.com" },
                PhoneNumber = "666-777-8888",
                DateOfBirth = new DateTime(1973, 10, 19),
                DeliveryAddress = new DeliveryAddress { Address = "606 Spruce Ave", City = "Dallas", Country = "USA" }
            },
            new Customer
            {
                Id = 10,
                FirstName = "Ava",
                LastName = "Thomas",
                Email = new EmailAddress { Value = "ava.t@example.com" },
                PhoneNumber = "333-444-5555",
                DateOfBirth = new DateTime(1998, 12, 25),
                DeliveryAddress = new DeliveryAddress { Address = "707 Willow Way", City = "San Jose", Country = "USA" }
            }
        };

    [Fact]
    public async Task GetCustomerById_ValidId_Successfully()
    {
        using var context = GetDbContext();

        var validId = 5;

        var repository = new CustomerRepository(context);

        var actualCustomer = await repository.GetCustomerByIdAsync(validId);
        
        Assert.NotNull(actualCustomer);
        Assert.Equal(validId, actualCustomer.Id);
    }
    
    [Fact]
    public async Task GetCustomerById_InvalidId_ReturnNull()
    {
        using var context = GetDbContext();
    
        var validId = 0;
    
        var repository = new CustomerRepository(context);
    
        var actualCustomer = await repository.GetCustomerByIdAsync(validId);
        
        Assert.Null(actualCustomer);
    }
    
    [Fact]
    public async Task GetCustomerById_NonExistedCustomerId_ReturnNull()
    {
        using var context = GetDbContext();
    
        var validId = 999;
    
        var repository = new CustomerRepository(context);
    
        var actualCustomer = await repository.GetCustomerByIdAsync(validId);
        
        Assert.Null(actualCustomer);
    }
    
    [Fact]
    public async Task GetCustomerByEmail_ValidEmail_Successfully()
    {
        using var context = GetDbContext();

        var validEmail = "william.m@example.com";

        var repository = new CustomerRepository(context);

        var actualCustomer = await repository.GetCustomerByEmailAsync(validEmail);
        
        Assert.NotNull(actualCustomer);
        Assert.Equal(validEmail, actualCustomer.Email.Value);
    }
    
    [Fact]
    public async Task GetCustomerById_InvalidEmail_ReturnNull()
    {
        using var context = GetDbContext();
    
        var validId = string.Empty;
    
        var repository = new CustomerRepository(context);
    
        var actualCustomer = await repository.GetCustomerByEmailAsync(validId);
        
        Assert.Null(actualCustomer);
    }
    
    [Fact]
    public async Task GetCustomerByEmail_NonExistedEmail_ReturnNull()
    {
        using var context = GetDbContext();
    
        var notExistedEmail = "not-existed-email@gmail.com";
    
        var repository = new CustomerRepository(context);
    
        var actualCustomer = await repository.GetCustomerByEmailAsync(notExistedEmail);
        
        Assert.Null(actualCustomer);
    }

    [Fact]
    public async Task GetCustomers_NoFilter_ReturnAllCustomers()
    {
        using var context = GetDbContext();
        
        var repository = new CustomerRepository(context);

        var customers = await repository.GetCustomersAsync(string.Empty, 100, 1);
        
        Assert.NotNull(customers);
        Assert.Equal(_sampleCustomers.Count, customers.Items.Count());
        Assert.Equal(_sampleCustomers.Count, customers.Total);
    }
    
    [Fact]
    public async Task GetCustomers_HavePaging_ReturnPagedCustomers()
    {
        using var context = GetDbContext();
        
        var repository = new CustomerRepository(context);

        int pageSize = 5;
        var customers = await repository.GetCustomersAsync(string.Empty, pageSize, 1);
        
        Assert.NotNull(customers);
        Assert.Equal(pageSize, customers.Items.Count());
        Assert.Equal(_sampleCustomers.Count, customers.Total);
    }
    
    [Fact]
    public async Task GetCustomers_FilterByFirstName_Successfully()
    {
        using var context = GetDbContext();
        
        var repository = new CustomerRepository(context);

        int pageSize = 5;

        var filter = "(FirstName eq `Olivia`)";
        
        var customers = await repository.GetCustomersAsync(filter, pageSize, 1);
        
        Assert.NotNull(customers);
        Assert.Single(customers.Items);
        
        Assert.Equal("Olivia", customers.Items.First().FirstName);
    }
    
    [Fact]
    public async Task GetCustomers_FilterByEmail_Successfully()
    {
        using var context = GetDbContext();
        
        var repository = new CustomerRepository(context);

        int pageSize = 5;

        var filter = "(Email.Value eq `emily.b@example.com`)";
        
        var customers = await repository.GetCustomersAsync(filter, pageSize, 1);
        
        Assert.NotNull(customers);
        Assert.Single(customers.Items);

        Assert.Equal("emily.b@example.com", customers.Items.First().Email.Value);
    }

    [Fact]
    public async Task CreateCustomer_ValidRequest_Successfully()
    {
        using var context = GetDbContext();
        
        var repository = new CustomerRepository(context);

        var validRequest = new Customer
        {
            FirstName = "Phuc",
            LastName = "Nguyen",
            Email = new EmailAddress { Value = "phucnguyenb@example.com" },
            PhoneNumber = "111-444-5555",
            DateOfBirth = new DateTime(1997, 09, 15),
            DeliveryAddress = new DeliveryAddress { Address = "Sample Address", City = "Ho Chi Minh City", Country = "Vietnam" }
        };
        
        var createdCustomer = await repository.CreateCustomerAsync(validRequest);
        
        Assert.NotNull(createdCustomer);
        Assert.True(createdCustomer.Id > 0);
    }
    
    [Fact]
    public async Task UpdateCustomer_ValidRequest_Successfully()
    {
        using var context = GetDbContext();
        
        var repository = new CustomerRepository(context);
        
        var customer = await context.Customers.FirstOrDefaultAsync(x => x.Id == 9);
        
        if (customer == null)
            throw new NullReferenceException();
        
        customer.Email.Value = "updated_email@test.com";
        customer.DeliveryAddress.Address = "Updated Address";
        customer.DeliveryAddress.City = "Updated City";
        customer.DeliveryAddress.Country = "Updated Country";
        
        var updatedCustomer = await repository.UpdateCustomerAsync(customer);
        
        Assert.NotNull(updatedCustomer);
        Assert.Equal(customer.Email.Value, updatedCustomer.Email.Value);
        Assert.Equal(customer.DeliveryAddress.Address, updatedCustomer.DeliveryAddress.Address);
        Assert.Equal(customer.DeliveryAddress.City, updatedCustomer.DeliveryAddress.City);
        Assert.Equal(customer.DeliveryAddress.Country, updatedCustomer.DeliveryAddress.Country);
    }

    [Fact]
    public async Task DeleteCustomer_ValidRequest_Successfully()
    {
        using var context = GetDbContext();
        
        var repository = new CustomerRepository(context);

        var validCustomerId = 1;
        
        var result = await repository.DeleteCustomerAsync(validCustomerId);
        Assert.True(result);
    }

    [Fact]
    public async Task DeleteCustomer_NotExistsCustomer_ReturnFalse()
    {
        using var context = GetDbContext();
        
        var repository = new CustomerRepository(context);

        var validCustomerId = 1000;
        
        var result = await repository.DeleteCustomerAsync(validCustomerId);
        Assert.False(result);
    }
    
    private SalesManagementDbContext GetDbContext()
    {
        var dbcContextOption = new DbContextOptionsBuilder<SalesManagementDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;
        
        var context = new SalesManagementDbContext(dbcContextOption);

        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();
        
        context.Customers.AddRange(_sampleCustomers);
        context.SaveChanges();
        
        return context;
    }
}