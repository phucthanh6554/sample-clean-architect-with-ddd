using System.Net;
using AutoMapper;
using SalesManagement.Application.Commons.Attributes;
using SalesManagement.Application.Commons.Results;
using SalesManagement.Domain.Vehicles;

namespace SalesManagement.Application.Vehicles.UpdateVehicle;

[UseCase]
public class UpdateVehicleUseCase : IUpdateVehicleUseCase
{
    private readonly IVehicleRepository _vehicleRepository;
    private readonly IMapper _mapper;

    public UpdateVehicleUseCase(IVehicleRepository vehicleRepository, IMapper mapper)
    {
        _vehicleRepository = vehicleRepository;
        _mapper = mapper;
    }

    public async Task<GeneralResult<Vehicle>> UpdateVehicleAsync(int vehicleId, UpdateVehicleCommand command)
    {
        var vehicle = await _vehicleRepository.GetVehicleByIdAsync(vehicleId);
        if (vehicle == null)
            return new GeneralResult<Vehicle>(HttpStatusCode.NotFound);

        var updateModel = _mapper.Map<VehicleUpdateModel>(command);
        var updateResult = Vehicle.Update(vehicle, updateModel);
        if (!updateResult.IsSuccess || updateResult.Entity == null)
            return new GeneralResult<Vehicle>(HttpStatusCode.BadRequest, updateResult.ErrorMessage);

        var updatedVehicle = await _vehicleRepository.UpdateVehicleAsync(updateResult.Entity);
        if (updatedVehicle == null)
            return new GeneralResult<Vehicle>(HttpStatusCode.InternalServerError);

        return new GeneralResult<Vehicle>(updatedVehicle);
    }
}
