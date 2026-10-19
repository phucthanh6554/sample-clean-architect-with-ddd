using SalesManagement.Application.Commons.Results;
using SalesManagement.Domain.Vehicles;

namespace SalesManagement.Application.Vehicles.CreateVehicle;

public interface ICreateVehicleUseCase
{
    Task<GeneralResult<Vehicle>> CreateVehicleAsync(CreateVehicleCommand command);
}
