using System.ComponentModel.DataAnnotations;

namespace SalesManagement.Application.Commons.Requests;

public class BaseApiListRequest
{
    public string FilterExpression { get; init; } = string.Empty;
    
    [Range(1, int.MaxValue)]
    public int Page { get; init; } = 1;
    
    [Range(1, int.MaxValue)]
    public int PageSize { get; init; } = 10;
}