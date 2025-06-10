using System.Net;

namespace SalesManagement.Application.Commons.Results;

public class GeneralResult<T>
{
    public HttpStatusCode StatusCode { get; init; }

    public string Message { get; init; }

    public readonly T? ReturnObject;
    
    public GeneralResult()
    {
        StatusCode = HttpStatusCode.OK;
        Message = string.Empty;
    }

    public GeneralResult(T returnObject)
    {
        StatusCode = HttpStatusCode.OK;
        Message = string.Empty;
        ReturnObject = returnObject;
    }

    public GeneralResult(HttpStatusCode statusCode, string message, T returnObject)
    {
        StatusCode = statusCode;
        Message = message;
        ReturnObject = returnObject;
    }
    
    public GeneralResult(HttpStatusCode statusCode, string message)
    {
        StatusCode = statusCode;
        Message = message;
    }
    
    public GeneralResult(HttpStatusCode statusCode, T returnObject)
    {
        StatusCode = statusCode;
        Message = string.Empty;
        ReturnObject = returnObject;
    }
    
    public GeneralResult(HttpStatusCode statusCode)
    {
        StatusCode = statusCode;
        Message = string.Empty;
    }
}