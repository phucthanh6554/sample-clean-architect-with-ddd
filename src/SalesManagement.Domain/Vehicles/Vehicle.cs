using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SalesManagement.Domain.Commons;

namespace SalesManagement.Domain.Vehicles;

public class Vehicle
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; init; }

    [Column(TypeName = "int")]
    public int CustomerId { get; init; }

    [Column(TypeName = "nvarchar(255)")]
    public string Branch { get; set; } = string.Empty;

    [Column(TypeName = "nvarchar(255)")]
    public string Model { get; set; } = string.Empty;

    [Column(TypeName = "nvarchar(255)")]
    public string Color { get; set; } = string.Empty;

    public static CreateEntityResult<Vehicle> Create(VehicleCreationModel creationModel)
    {
        if (creationModel.CustomerId <= 0)
            return new CreateEntityResult<Vehicle>("Customer Id is invalid");

        if (string.IsNullOrWhiteSpace(creationModel.Branch))
            return new CreateEntityResult<Vehicle>("Branch cannot be empty");

        if (string.IsNullOrWhiteSpace(creationModel.Model))
            return new CreateEntityResult<Vehicle>("Model cannot be empty");

        if (string.IsNullOrWhiteSpace(creationModel.Color))
            return new CreateEntityResult<Vehicle>("Color cannot be empty");

        var vehicle = new Vehicle
        {
            CustomerId = creationModel.CustomerId,
            Branch = creationModel.Branch,
            Model = creationModel.Model,
            Color = creationModel.Color
        };

        return new CreateEntityResult<Vehicle>(vehicle);
    }

    public static CreateEntityResult<Vehicle> Update(Vehicle vehicle, VehicleUpdateModel updateModel)
    {
        if (string.IsNullOrWhiteSpace(updateModel.Branch))
            return new CreateEntityResult<Vehicle>("Branch cannot be empty");

        if (string.IsNullOrWhiteSpace(updateModel.Model))
            return new CreateEntityResult<Vehicle>("Model cannot be empty");

        if (string.IsNullOrWhiteSpace(updateModel.Color))
            return new CreateEntityResult<Vehicle>("Color cannot be empty");

        vehicle.Branch = updateModel.Branch;
        vehicle.Model = updateModel.Model;
        vehicle.Color = updateModel.Color;

        return new CreateEntityResult<Vehicle>(vehicle);
    }
}
