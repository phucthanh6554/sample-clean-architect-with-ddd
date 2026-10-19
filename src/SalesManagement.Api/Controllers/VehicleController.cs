using Microsoft.AspNetCore.Mvc;
using SalesManagement.Api.Commons;
using SalesManagement.Application.Commons.Requests;
using SalesManagement.Application.Vehicles.CreateVehicle;
using SalesManagement.Application.Vehicles.DeleteVehicle;
using SalesManagement.Application.Vehicles.GetVehicleById;
using SalesManagement.Application.Vehicles.GetVehicleList;
using SalesManagement.Application.Vehicles.UpdateVehicle;

namespace SalesManagement.Api.Controllers;

[Route("api/vehicles")]
public class VehicleController : ApiBaseController
{
    private readonly ICreateVehicleUseCase _createVehicleUseCase;
    private readonly IGetVehicleListUseCase _getVehicleListUseCase;
    private readonly IGetVehicleByIdUseCase _getVehicleByIdUseCase;
    private readonly IUpdateVehicleUseCase _updateVehicleUseCase;
    private readonly IDeleteVehicleUseCase _deleteVehicleUseCase;

    public VehicleController(
        ICreateVehicleUseCase createVehicleUseCase,
        IGetVehicleListUseCase getVehicleListUseCase,
        IGetVehicleByIdUseCase getVehicleByIdUseCase,
        IUpdateVehicleUseCase updateVehicleUseCase,
        IDeleteVehicleUseCase deleteVehicleUseCase)
    {
        _createVehicleUseCase = createVehicleUseCase;
        _getVehicleListUseCase = getVehicleListUseCase;
        _getVehicleByIdUseCase = getVehicleByIdUseCase;
        _updateVehicleUseCase = updateVehicleUseCase;
        _deleteVehicleUseCase = deleteVehicleUseCase;
    }

    [HttpGet]
    public async Task<IActionResult> GetVehiclesAsync([FromQuery] BaseApiListRequest request)
    {
        var result = await _getVehicleListUseCase.GetVehicleListAsync(request);
        return ReturnResponse(result);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetVehicleByIdAsync([FromRoute] int id)
    {
        var result = await _getVehicleByIdUseCase.GetVehicleByIdAsync(id);
        return ReturnResponse(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateVehicleAsync([FromBody] CreateVehicleCommand command)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var result = await _createVehicleUseCase.CreateVehicleAsync(command);
        return ReturnResponse(result);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateVehicleAsync([FromRoute] int id, [FromBody] UpdateVehicleCommand command)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var result = await _updateVehicleUseCase.UpdateVehicleAsync(id, command);
        return ReturnResponse(result);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteVehicleAsync([FromRoute] int id)
    {
        var result = await _deleteVehicleUseCase.DeleteVehicleAsync(id);
        return ReturnResponse(result);
    }
}
