using System.Net;
using AutoMapper;
using SalesManagement.Application.Commons.Attributes;
using SalesManagement.Application.Commons.Results;
using SalesManagement.Domain.Vehicles;

namespace SalesManagement.Application.Vehicles.CreateVehicle;

[UseCase]
public class CreateVehicleUseCase : ICreateVehicleUseCase
{
    private readonly IVehicleRepository _vehicleRepository;
    private readonly IMapper _mapper;

    public CreateVehicleUseCase(IVehicleRepository vehicleRepository, IMapper mapper)
    {
        _vehicleRepository = vehicleRepository;
        _mapper = mapper;
    }

    public async Task<GeneralResult<Vehicle>> CreateVehicleAsync(CreateVehicleCommand command)
    {
        var creationModel = _mapper.Map<VehicleCreationModel>(command);
        var createResult = Vehicle.Create(creationModel);

        if (!createResult.IsSuccess || createResult.Entity == null)
            return new GeneralResult<Vehicle>(HttpStatusCode.BadRequest, createResult.ErrorMessage);

        var createdVehicle = await _vehicleRepository.CreateVehicleAsync(createResult.Entity);
        if (createdVehicle == null)
            return new GeneralResult<Vehicle>(HttpStatusCode.InternalServerError, "Vehicle could not be created");

        return new GeneralResult<Vehicle>(createdVehicle);
    }
}
