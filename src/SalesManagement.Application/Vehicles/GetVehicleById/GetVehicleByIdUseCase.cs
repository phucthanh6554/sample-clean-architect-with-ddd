using System.Net;
using SalesManagement.Application.Commons.Attributes;
using SalesManagement.Application.Commons.Results;
using SalesManagement.Domain.Vehicles;

namespace SalesManagement.Application.Vehicles.GetVehicleById;

[UseCase]
public class GetVehicleByIdUseCase : IGetVehicleByIdUseCase
{
    private readonly IVehicleRepository _vehicleRepository;

    public GetVehicleByIdUseCase(IVehicleRepository vehicleRepository)
    {
        _vehicleRepository = vehicleRepository;
    }

    public async Task<GeneralResult<Vehicle>> GetVehicleByIdAsync(int vehicleId)
    {
        var vehicle = await _vehicleRepository.GetVehicleByIdAsync(vehicleId);
        if (vehicle == null)
            return new GeneralResult<Vehicle>(HttpStatusCode.NotFound);

        return new GeneralResult<Vehicle>(vehicle);
    }
}
