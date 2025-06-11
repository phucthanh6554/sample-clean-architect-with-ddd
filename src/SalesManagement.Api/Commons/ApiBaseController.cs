using System.Net;
using Microsoft.AspNetCore.Mvc;
using SalesManagement.Application.Commons.Results;

namespace SalesManagement.Api.Commons;

public class ApiBaseController : ControllerBase
{
    protected IActionResult ReturnResponse<T>(GeneralResult<T> result)
    {
        if(result.StatusCode == HttpStatusCode.OK)
            return Ok(result.ReturnObject);
        
        if(result.StatusCode == HttpStatusCode.NotFound)
            return NotFound(result.ReturnObject);
        
        if(result.StatusCode == HttpStatusCode.BadRequest)
            return BadRequest(result.ReturnObject);
        
        if(result.StatusCode == HttpStatusCode.Unauthorized)
            return Unauthorized();
        
        if(result.StatusCode == HttpStatusCode.Forbidden)
            return Forbid();
        
        if(result.StatusCode == HttpStatusCode.NoContent)
            return NoContent();
        
        return StatusCode((int)result.StatusCode, result.ReturnObject);
    }
}