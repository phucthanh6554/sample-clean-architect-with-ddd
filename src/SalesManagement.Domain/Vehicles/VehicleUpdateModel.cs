namespace SalesManagement.Domain.Vehicles;

public record VehicleUpdateModel
{
    public string Branch { get; init; } = string.Empty;

    public string Model { get; init; } = string.Empty;

    public string Color { get; init; } = string.Empty;
}
