using AutoMapper;
using SalesManagement.Application.Customers.CreateCustomer;
using SalesManagement.Domain.Customers;
using SalesManagement.Domain.Customers.ValueObjects;

namespace SalesManagement.Application.Commons.MappingProfiles;

public class CustomerMappingProfile : Profile
{
    public CustomerMappingProfile()
    {
        CreateMap<CreateCustomerCommand, Customer>()
            .ForMember(x => x.Email, opt => opt.MapFrom(src => new EmailAddress { Value = src.Email }))
            .ForMember(x => x.DeliveryAddress, opt => opt.MapFrom(src => new DeliveryAddress
            {
                Address = src.Address,
                City = src.City,
                Country = src.Country,
            }));

    }
}