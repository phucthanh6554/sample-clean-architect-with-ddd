using SalesManagement.Application.Commons.Results;

namespace SalesManagement.Application.Vehicles.DeleteVehicle;

public interface IDeleteVehicleUseCase
{
    Task<GeneralResult<bool>> DeleteVehicleAsync(int vehicleId);
}
