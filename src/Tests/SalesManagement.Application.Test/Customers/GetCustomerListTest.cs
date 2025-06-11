using System.Net;
using AutoMapper;
using Moq;
using SalesManagement.Application.Commons.MappingProfiles;
using SalesManagement.Application.Commons.Requests;
using SalesManagement.Application.Customers.GetCustomerList;
using SalesManagement.Domain.Commons;
using SalesManagement.Domain.Customers;
using SalesManagement.Domain.Customers.ValueObjects;

namespace SalesManagement.Application.Test.Customers;

public class GetCustomerListTest
{
    private readonly IMapper _mapper;
    
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

    public GetCustomerListTest()
    {
        var mapperConfiguration = new MapperConfiguration(x =>
        {
            x.AddProfile<CustomerMappingProfile>();
        });
        
        _mapper = mapperConfiguration.CreateMapper();
    }

    [Fact]
    public async Task GetCustomerList_ValidData_Successfully()
    {
        var mockRepository = new Mock<ICustomerRepository>();

        var pagedCustomerList = new PagedResult<Customer>(_sampleCustomers.Count, _sampleCustomers);

        mockRepository.Setup(x => x.GetCustomersAsync(string.Empty, 10, 1))
            .ReturnsAsync(pagedCustomerList);
        
        var getCustomerListUseCase = new GetCustomerListUseCase(mockRepository.Object, _mapper);

        var validRequest = new BaseApiListRequest
        {
            FilterExpression = string.Empty,
            Page = 1,
            PageSize = 10
        };

        var actualCustomerList = await getCustomerListUseCase.GetCustomerListAsync(validRequest);
        
        Assert.NotNull(actualCustomerList);
        Assert.NotNull(actualCustomerList.ReturnObject);
        Assert.Equal(HttpStatusCode.OK, actualCustomerList.StatusCode);
        Assert.Equal(10, actualCustomerList.ReturnObject.Total);
    }
}