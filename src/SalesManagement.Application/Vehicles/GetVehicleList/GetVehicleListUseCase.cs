using AutoMapper;
using SalesManagement.Application.Commons.Attributes;
using SalesManagement.Application.Commons.Requests;
using SalesManagement.Application.Commons.Results;
using SalesManagement.Domain.Vehicles;

namespace SalesManagement.Application.Vehicles.GetVehicleList;

[UseCase]
public class GetVehicleListUseCase : IGetVehicleListUseCase
{
    private readonly IVehicleRepository _vehicleRepository;
    private readonly IMapper _mapper;

    public GetVehicleListUseCase(IVehicleRepository vehicleRepository, IMapper mapper)
    {
        _vehicleRepository = vehicleRepository;
        _mapper = mapper;
    }

    public async Task<PagingListResult<VehicleListResponse>> GetVehicleListAsync(BaseApiListRequest request)
    {
        var listResult = await _vehicleRepository.GetVehiclesAsync(
            request.FilterExpression,
            request.PageSize,
            request.Page);

        var responseVehicles = _mapper.Map<List<VehicleListResponse>>(listResult.Items);
        return new PagingListResult<VehicleListResponse>(listResult.Total, responseVehicles);
    }
}
