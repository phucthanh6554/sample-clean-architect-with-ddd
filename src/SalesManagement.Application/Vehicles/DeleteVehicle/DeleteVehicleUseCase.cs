using System.Net;
using SalesManagement.Application.Commons.Attributes;
using SalesManagement.Application.Commons.Results;
using SalesManagement.Domain.Vehicles;

namespace SalesManagement.Application.Vehicles.DeleteVehicle;

[UseCase]
public class DeleteVehicleUseCase : IDeleteVehicleUseCase
{
    private readonly IVehicleRepository _vehicleRepository;

    public DeleteVehicleUseCase(IVehicleRepository vehicleRepository)
    {
        _vehicleRepository = vehicleRepository;
    }

    public async Task<GeneralResult<bool>> DeleteVehicleAsync(int vehicleId)
    {
        var deleted = await _vehicleRepository.DeleteVehicleAsync(vehicleId);
        if (!deleted)
            return new GeneralResult<bool>(HttpStatusCode.NotFound);

        return new GeneralResult<bool>(deleted);
    }
}
