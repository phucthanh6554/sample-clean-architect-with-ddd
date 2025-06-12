using System.Net;
using AutoMapper;
using Moq;
using SalesManagement.Application.Commons.MappingProfiles;
using SalesManagement.Application.Customers.UpdateCustomer;
using SalesManagement.Domain.Customers;
using SalesManagement.Domain.Customers.ValueObjects;

namespace SalesManagement.Application.Test.Customers;

public class UpdateCustomerTest
{
    private readonly IMapper _mapper;

    public UpdateCustomerTest()
    {
        var mapperConfiguration = new MapperConfiguration(mapper =>
        {
            mapper.AddProfile<CustomerMappingProfile>();
        });
        
        _mapper = mapperConfiguration.CreateMapper();
    }
    
    [Fact]
    public async Task UpdateCustomer_ValidRequest_Successfully()
    {
        var mockRepository = new Mock<ICustomerRepository>();

        var customerId = 3;
        
        var validCustomer = new Customer
        {
            Id = 3,
            FirstName = "Robert",
            LastName = "Johnson",
            Email = new EmailAddress { Value = "robert.j@example.com" },
            PhoneNumber = "555-123-4567",
            DateOfBirth = new DateTime(1978, 3, 10),
            DeliveryAddress = new DeliveryAddress { Address = "789 Pine Ln", City = "Chicago", Country = "USA" }
        };

        var validUpdateCommand = new UpdateCustomerCommand
        {
            Email = "updated_email@gmail.com",
            Address = "updated_address",
            City = "updated_city",
            Country = "updated_country",
        };
        
        mockRepository.Setup(x => x.GetCustomerByIdAsync(customerId)).ReturnsAsync(validCustomer);
        
        var updatedCustomer = new Customer
        {
            Id = 3,
            FirstName = "Robert",
            LastName = "Johnson",
            Email = new EmailAddress { Value = "updated_email@gmail.com" },
            PhoneNumber = "555-123-4567",
            DateOfBirth = new DateTime(1978, 3, 10),
            DeliveryAddress = new DeliveryAddress { 
                Address = "updated_address", 
                City = "updated_city", 
                Country = "updated_country" 
            }
        };
        
        mockRepository.Setup(x => x.UpdateCustomerAsync(validCustomer)).ReturnsAsync(updatedCustomer);
        
        var updateCustomerUseCase = new UpdateCustomerUseCase(mockRepository.Object, _mapper);

        var actualResult = await updateCustomerUseCase.UpdateCustomerAsync(customerId, validUpdateCommand);
        
        Assert.NotNull(actualResult);
        Assert.NotNull(actualResult.ReturnObject);
        Assert.Equal(HttpStatusCode.OK, actualResult.StatusCode);
        Assert.Equal(validUpdateCommand.Email, actualResult.ReturnObject.Email.Value);
    }
    
    [Fact]
    public async Task UpdateCustomer_NotExistsCustomerId_ReturnNotFound()
    {
        var mockRepository = new Mock<ICustomerRepository>();

        var customerId = 999;

        var validUpdateCommand = new UpdateCustomerCommand
        {
            Email = "updated_email@gmail.com",
            Address = "updated_address",
            City = "updated_city",
            Country = "updated_country",
        };
        
        mockRepository.Setup(x => x.GetCustomerByIdAsync(customerId))
            .ReturnsAsync(null as Customer);
        
        var updateCustomerUseCase = new UpdateCustomerUseCase(mockRepository.Object, _mapper);

        var actualResult = await updateCustomerUseCase.UpdateCustomerAsync(customerId, validUpdateCommand);
        
        Assert.NotNull(actualResult);
        Assert.Null(actualResult.ReturnObject);
        Assert.Equal(HttpStatusCode.NotFound, actualResult.StatusCode);
    }
    
    [Fact]
    public async Task UpdateCustomer_InvalidEmail_ReturnBadRequest()
    {
        var mockRepository = new Mock<ICustomerRepository>();

        var customerId = 3;
        
        var validCustomer = new Customer
        {
            Id = 3,
            FirstName = "Robert",
            LastName = "Johnson",
            Email = new EmailAddress { Value = "robert.j@example.com" },
            PhoneNumber = "555-123-4567",
            DateOfBirth = new DateTime(1978, 3, 10),
            DeliveryAddress = new DeliveryAddress { Address = "789 Pine Ln", City = "Chicago", Country = "USA" }
        };

        var validUpdateCommand = new UpdateCustomerCommand
        {
            Email = "updated_email",
            Address = "updated_address",
            City = "updated_city",
            Country = "updated_country",
        };
        
        mockRepository.Setup(x => x.GetCustomerByIdAsync(customerId))
            .ReturnsAsync(validCustomer);
        
        var updateCustomerUseCase = new UpdateCustomerUseCase(mockRepository.Object, _mapper);

        var actualResult = await updateCustomerUseCase.UpdateCustomerAsync(customerId, validUpdateCommand);
        
        Assert.NotNull(actualResult);
        Assert.Null(actualResult.ReturnObject);
        Assert.Equal(HttpStatusCode.BadRequest, actualResult.StatusCode);
    }
    
    [Fact]
    public async Task UpdateCustomer_InvalidAddress_ReturnBadRequest()
    {
        var mockRepository = new Mock<ICustomerRepository>();

        var customerId = 3;
        
        var validCustomer = new Customer
        {
            Id = 3,
            FirstName = "Robert",
            LastName = "Johnson",
            Email = new EmailAddress { Value = "robert.j@example.com" },
            PhoneNumber = "555-123-4567",
            DateOfBirth = new DateTime(1978, 3, 10),
            DeliveryAddress = new DeliveryAddress { Address = "789 Pine Ln", City = "Chicago", Country = "USA" }
        };

        var validUpdateCommand = new UpdateCustomerCommand
        {
            Email = "updated_email@gmail.com",
            Address = string.Empty, // invalid address
            City = "updated_city",
            Country = "updated_country",
        };
        
        mockRepository.Setup(x => x.GetCustomerByIdAsync(customerId))
            .ReturnsAsync(validCustomer);
        
        var updateCustomerUseCase = new UpdateCustomerUseCase(mockRepository.Object, _mapper);

        var actualResult = await updateCustomerUseCase.UpdateCustomerAsync(customerId, validUpdateCommand);
        
        Assert.NotNull(actualResult);
        Assert.Null(actualResult.ReturnObject);
        Assert.Equal(HttpStatusCode.BadRequest, actualResult.StatusCode);
    }
}