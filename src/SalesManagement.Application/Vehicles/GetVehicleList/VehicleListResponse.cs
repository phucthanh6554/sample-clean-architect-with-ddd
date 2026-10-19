namespace SalesManagement.Application.Vehicles.GetVehicleList;

public class VehicleListResponse
{
    public int Id { get; init; }

    public int CustomerId { get; init; }

    public string Branch { get; init; } = string.Empty;

    public string Model { get; init; } = string.Empty;

    public string Color { get; init; } = string.Empty;
}
