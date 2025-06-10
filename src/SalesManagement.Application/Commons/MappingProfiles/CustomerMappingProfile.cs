using AutoMapper;
using SalesManagement.Application.Customers.CreateCustomer;
using SalesManagement.Domain.Customers;

namespace SalesManagement.Application.Commons.MappingProfiles;

public class CustomerMappingProfile : Profile
{
    public CustomerMappingProfile()
    {
        CreateMap<CreateCustomerCommand, Customer>()
            .ForMember(x => x.Email.Value, opt => opt.MapFrom(src => src.Email));
        
        CreateMap<CreateCustomerCommand, Customer>()
            .ForMember(x => x.DeliveryAddress.Address, opt => opt.MapFrom(src => src.Address));
        
        CreateMap<CreateCustomerCommand, Customer>()
            .ForMember(x => x.DeliveryAddress.City, opt => opt.MapFrom(src => src.City));
        
        CreateMap<CreateCustomerCommand, Customer>()
            .ForMember(x => x.DeliveryAddress.Country, opt => opt.MapFrom(src => src.Country));
    }
}