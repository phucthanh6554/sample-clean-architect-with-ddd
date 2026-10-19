using SalesManagement.Application.Commons.Results;
using SalesManagement.Domain.Vehicles;

namespace SalesManagement.Application.Vehicles.UpdateVehicle;

public interface IUpdateVehicleUseCase
{
    Task<GeneralResult<Vehicle>> UpdateVehicleAsync(int vehicleId, UpdateVehicleCommand command);
}
