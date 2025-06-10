using System.Net;
using SalesManagement.Domain.Commons;

namespace SalesManagement.Application.Commons.Results;

public class PagingListResult<T> : GeneralResult<PagedResult<T>>
{
    public PagingListResult(int total ,IEnumerable<T> returnObject) 
        : base(new PagedResult<T>(total, returnObject))
    {
    }
    
    public PagingListResult(HttpStatusCode statusCode) : base(statusCode){}
    
    public PagingListResult(HttpStatusCode statusCode, string message) : base(statusCode, message){}
}