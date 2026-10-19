using System.ComponentModel.DataAnnotations;

namespace SalesManagement.Application.Vehicles.UpdateVehicle;

public class UpdateVehicleCommand
{
    [Required]
    public string Branch { get; init; } = string.Empty;

    [Required]
    public string Model { get; init; } = string.Empty;

    [Required]
    public string Color { get; init; } = string.Empty;
}
