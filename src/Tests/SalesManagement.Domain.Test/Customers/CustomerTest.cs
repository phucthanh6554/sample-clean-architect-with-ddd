using SalesManagement.Domain.Customers;
using SalesManagement.Domain.Customers.ValueObjects;

namespace SalesManagement.Domain.Test.Customers;

public class CustomerTest
{
    [Fact]
    public void IsValid_ValidCustomer_Successfully()
    {
        var validCustomer = new CustomerCreationModel
        {
            FirstName = "John",
            LastName = "Doe",
            Email = "john.doe@gmail.com",
            DateOfBirth = new DateTime(1980, 01, 01),
            Address = "123 Main Street",
            City = "London",
            Country = "England"
        };
        
        var actualResult = Customer.Create(validCustomer);
        
        Assert.NotNull(actualResult);
        Assert.True(actualResult.IsSuccess);
        Assert.NotNull(actualResult.Entity);
    }
    
    [Fact]
    public void IsValid_EmptyFirstName_ReturnFalse()
    {
        var invalidCustomer = new CustomerCreationModel
        {
            LastName = "Doe",
            Email = "john.doe@gmail.com",
            DateOfBirth = new DateTime(1980, 01, 01),
            Address = "123 Main Street",
            City = "London",
            Country = "England"
        };
        
        var actualResult = Customer.Create(invalidCustomer);
        
        Assert.False(actualResult.IsSuccess);
        Assert.Null(actualResult.Entity);
    }
    
    [Fact]
    public void IsValid_EmptyLastName_ReturnFalse()
    {
        var invalidCustomer = new CustomerCreationModel
        {
            FirstName = "John",
            Email = "john.doe@gmail.com",
            DateOfBirth = new DateTime(1980, 01, 01),
            Address = "123 Main Street",
            City = "London",
            Country = "England"
        };
        
        var actualResult = Customer.Create(invalidCustomer);
        
        Assert.False(actualResult.IsSuccess);
        Assert.Null(actualResult.Entity);
    }
    
    [Fact]
    public void IsValid_InvalidEmail_ReturnFalse()
    {
        var invalidCustomer = new CustomerCreationModel
        {
            FirstName = "John",
            LastName = "Doe",
            Email = "john.doe",
            DateOfBirth = new DateTime(1980, 01, 01),
            Address = "123 Main Street",
            City = "London",
            Country = "England"
        };
        
        var actualResult = Customer.Create(invalidCustomer);
        
        Assert.False(actualResult.IsSuccess);
        Assert.Null(actualResult.Entity);
    }
    
    [Fact]
    public void IsValid_InvalidAddress_ReturnFalse()
    {
        var invalidCustomer = new CustomerCreationModel
        {
            FirstName = "John",
            LastName = "Doe",
            Email = "john.doe@gmail.com",
            DateOfBirth = new DateTime(1980, 01, 01),
            City = "London",
            Country = "England"
        };
        
        var actualResult = Customer.Create(invalidCustomer);
        
        Assert.False(actualResult.IsSuccess);
        Assert.Null(actualResult.Entity);
    }
    
    [Fact]
    public void IsValid_InvalidCity_ReturnFalse()
    {
        var invalidCustomer = new CustomerCreationModel
        {
            FirstName = "John",
            LastName = "Doe",
            Email = "john.doe@gmail.com",
            DateOfBirth = new DateTime(1980, 01, 01),
            Address = "123 Main Street",
            Country = "England"
        };
        
        var actualResult = Customer.Create(invalidCustomer);
        
        Assert.False(actualResult.IsSuccess);
        Assert.Null(actualResult.Entity);
    }
    
    [Fact]
    public void IsValid_InvalidCountry_ReturnFalse()
    {
        var invalidCustomer = new CustomerCreationModel
        {
            FirstName = "John",
            LastName = "Doe",
            Email = "john.doe@gmail.com",
            DateOfBirth = new DateTime(1980, 01, 01),
            Address = "123 Main Street",
            City = "London"
        };
        
        var actualResult = Customer.Create(invalidCustomer);
        
        Assert.False(actualResult.IsSuccess);
        Assert.Null(actualResult.Entity);
    }
}