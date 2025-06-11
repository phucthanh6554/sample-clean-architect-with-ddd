using System.Net;
using AutoMapper;
using Moq;
using SalesManagement.Application.Commons.MappingProfiles;
using SalesManagement.Application.Customers.CreateCustomer;
using SalesManagement.Domain.Customers;

namespace SalesManagement.Application.Test.Customers;

public class CreateCustomerTest
{
    private readonly IMapper _mapper;

    public CreateCustomerTest()
    {
        var mapperConfiguration = new MapperConfiguration(x =>
        {
            x.AddProfile<CustomerMappingProfile>();
        });
        
        _mapper = mapperConfiguration.CreateMapper();
    }
    
    [Fact]
    public async Task CreateCustomer_ValidRequest_Successfully()
    {
        var mockRepository = new Mock<ICustomerRepository>();
        
        var validCommand = new CreateCustomerCommand
        {
            FirstName = "John",
            LastName = "Doe",
            Email = "john.doe@gmail.com",
            PhoneNumber = "123456789",
            DateOfBirth = new DateTime(1980, 01, 01),
            Address = "Some address",
            City = "Some city",
            Country = "Vietnam"
        };

        var createdCustomer = new Customer();
        
        mockRepository.Setup(x => x.CreateCustomerAsync(It.IsAny<Customer>())).ReturnsAsync(createdCustomer);
        
        var createCustomerUseCase = new CreateCustomerUseCase(mockRepository.Object, _mapper);
        
        var actualResult = await createCustomerUseCase.CreateCustomerAsync(validCommand);
        
        Assert.NotNull(actualResult);
        Assert.NotNull(actualResult.ReturnObject);
        Assert.Equal(HttpStatusCode.OK, actualResult.StatusCode);
    }
    
    [Fact]
    public async Task CreateCustomer_InvalidFirstName_ReturnBadRequest()
    {
        var mockRepository = new Mock<ICustomerRepository>();
        
        var validCommand = new CreateCustomerCommand
        {
            FirstName = string.Empty, // Invalid FirstName
            LastName = "Doe",
            Email = "john.doe@gmail.com",
            PhoneNumber = "123456789",
            DateOfBirth = new DateTime(1980, 01, 01),
            Address = "Some address",
            City = "Some city",
            Country = "Vietnam"
        };

        var createdCustomer = new Customer();
        
        mockRepository.Setup(x => x.CreateCustomerAsync(It.IsAny<Customer>())).ReturnsAsync(createdCustomer);
        
        var createCustomerUseCase = new CreateCustomerUseCase(mockRepository.Object, _mapper);
        
        var actualResult = await createCustomerUseCase.CreateCustomerAsync(validCommand);
        
        Assert.NotNull(actualResult);
        Assert.Null(actualResult.ReturnObject);
        Assert.Equal(HttpStatusCode.BadRequest, actualResult.StatusCode);
    }
    
    [Fact]
    public async Task CreateCustomer_InvalidLastName_ReturnBadRequest()
    {
        var mockRepository = new Mock<ICustomerRepository>();
        
        var validCommand = new CreateCustomerCommand
        {
            FirstName = "John",
            LastName = string.Empty, // Invalid LastName
            Email = "john.doe@gmail.com",
            PhoneNumber = "123456789",
            DateOfBirth = new DateTime(1980, 01, 01),
            Address = "Some address",
            City = "Some city",
            Country = "Vietnam"
        };

        var createdCustomer = new Customer();
        
        mockRepository.Setup(x => x.CreateCustomerAsync(It.IsAny<Customer>())).ReturnsAsync(createdCustomer);
        
        var createCustomerUseCase = new CreateCustomerUseCase(mockRepository.Object, _mapper);
        
        var actualResult = await createCustomerUseCase.CreateCustomerAsync(validCommand);
        
        Assert.NotNull(actualResult);
        Assert.Null(actualResult.ReturnObject);
        Assert.Equal(HttpStatusCode.BadRequest, actualResult.StatusCode);
    }
    
    [Fact]
    public async Task CreateCustomer_InvalidEmail_ReturnBadRequest()
    {
        var mockRepository = new Mock<ICustomerRepository>();
        
        var validCommand = new CreateCustomerCommand
        {
            FirstName = "John",
            LastName = "Doe",
            Email = "john.doe", // Invalid Email
            PhoneNumber = "123456789",
            DateOfBirth = new DateTime(1980, 01, 01),
            Address = "Some address",
            City = "Some city",
            Country = "Vietnam"
        };

        var createdCustomer = new Customer();
        
        mockRepository.Setup(x => x.CreateCustomerAsync(It.IsAny<Customer>())).ReturnsAsync(createdCustomer);
        
        var createCustomerUseCase = new CreateCustomerUseCase(mockRepository.Object, _mapper);
        
        var actualResult = await createCustomerUseCase.CreateCustomerAsync(validCommand);
        
        Assert.NotNull(actualResult);
        Assert.Null(actualResult.ReturnObject);
        Assert.Equal(HttpStatusCode.BadRequest, actualResult.StatusCode);
    }
}