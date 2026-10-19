using SalesManagement.Application.Commons.Results;
using SalesManagement.Domain.Vehicles;

namespace SalesManagement.Application.Vehicles.GetVehicleById;

public interface IGetVehicleByIdUseCase
{
    Task<GeneralResult<Vehicle>> GetVehicleByIdAsync(int vehicleId);
}
