using FilterExpression.Extension;
using Microsoft.EntityFrameworkCore;
using SalesManagement.Domain.Commons;
using SalesManagement.Domain.Vehicles;

namespace SalesManagement.Infrastructure.Repositories;

public class VehicleRepository : IVehicleRepository
{
    private readonly SalesManagementDbContext _context;

    public VehicleRepository(SalesManagementDbContext context)
    {
        _context = context;
    }

    public async Task<Vehicle?> GetVehicleByIdAsync(int vehicleId)
    {
        if (vehicleId <= 0)
            return null;

        return await _context.Vehicles
            .AsNoTracking()
            .FirstOrDefaultAsync(vehicle => vehicle.Id == vehicleId);
    }

    public async Task<PagedResult<Vehicle>> GetVehiclesAsync(string filterExpression, int pageSize, int page)
    {
        var query = _context.Vehicles.Filter(filterExpression);
        var count = await query.CountAsync();

        var vehicles = await query
            .AsNoTracking()
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return new PagedResult<Vehicle>(count, vehicles);
    }

    public async Task<Vehicle?> CreateVehicleAsync(Vehicle vehicle)
    {
        _context.Vehicles.Add(vehicle);
        await _context.SaveChangesAsync();
        return vehicle;
    }

    public async Task<Vehicle?> UpdateVehicleAsync(Vehicle vehicle)
    {
        _context.Vehicles.Update(vehicle);
        await _context.SaveChangesAsync();
        return vehicle;
    }

    public async Task<bool> DeleteVehicleAsync(int vehicleId)
    {
        if (vehicleId <= 0)
            return false;

        var vehicle = await _context.Vehicles.FindAsync(vehicleId);
        if (vehicle == null)
            return false;

        _context.Vehicles.Remove(vehicle);
        return await _context.SaveChangesAsync() > 0;
    }
}
