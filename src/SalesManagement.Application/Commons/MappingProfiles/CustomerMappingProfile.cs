using AutoMapper;
using SalesManagement.Application.Customers.CreateCustomer;
using SalesManagement.Application.Customers.GetCustomerList;
using SalesManagement.Domain.Customers;
using SalesManagement.Domain.Customers.ValueObjects;

namespace SalesManagement.Application.Commons.MappingProfiles;

public class CustomerMappingProfile : Profile
{
    public CustomerMappingProfile()
    {
        CreateMap<CreateCustomerCommand, CustomerCreationModel>();

        CreateMap<Customer, CustomerListResponse>()
            .ForMember(x => x.Email, opt => opt.MapFrom(src => src.Email.Value))
            .ForMember(x => x.Address, opt => opt.MapFrom(src => src.DeliveryAddress.Address))
            .ForMember(x => x.City, opt => opt.MapFrom(src => src.DeliveryAddress.City))
            .ForMember(x => x.Country, opt => opt.MapFrom(src => src.DeliveryAddress.Country));

    }
}