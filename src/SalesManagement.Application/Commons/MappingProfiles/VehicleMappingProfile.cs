using AutoMapper;
using SalesManagement.Application.Vehicles.CreateVehicle;
using SalesManagement.Application.Vehicles.GetVehicleList;
using SalesManagement.Application.Vehicles.UpdateVehicle;
using SalesManagement.Domain.Vehicles;

namespace SalesManagement.Application.Commons.MappingProfiles;

public class VehicleMappingProfile : Profile
{
    public VehicleMappingProfile()
    {
        CreateMap<CreateVehicleCommand, VehicleCreationModel>();
        CreateMap<Vehicle, VehicleListResponse>();
        CreateMap<UpdateVehicleCommand, VehicleUpdateModel>();
    }
}
