using SalesManagement.Domain.Commons;

namespace SalesManagement.Domain.Vehicles;

public interface IVehicleRepository
{
    Task<Vehicle?> GetVehicleByIdAsync(int vehicleId);

    Task<PagedResult<Vehicle>> GetVehiclesAsync(string filterExpression, int pageSize, int page);

    Task<Vehicle?> CreateVehicleAsync(Vehicle vehicle);

    Task<Vehicle?> UpdateVehicleAsync(Vehicle vehicle);

    Task<bool> DeleteVehicleAsync(int vehicleId);
}
