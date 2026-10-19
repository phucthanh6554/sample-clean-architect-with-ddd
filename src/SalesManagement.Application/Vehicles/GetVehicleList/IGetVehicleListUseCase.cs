using SalesManagement.Application.Commons.Requests;
using SalesManagement.Application.Commons.Results;

namespace SalesManagement.Application.Vehicles.GetVehicleList;

public interface IGetVehicleListUseCase
{
    Task<PagingListResult<VehicleListResponse>> GetVehicleListAsync(BaseApiListRequest request);
}
