using System.ComponentModel.DataAnnotations;

namespace SalesManagement.Application.Vehicles.CreateVehicle;

public class CreateVehicleCommand
{
    [Range(1, int.MaxValue)]
    public int CustomerId { get; init; }

    [Required]
    public string Branch { get; init; } = string.Empty;

    [Required]
    public string Model { get; init; } = string.Empty;

    [Required]
    public string Color { get; init; } = string.Empty;
}
