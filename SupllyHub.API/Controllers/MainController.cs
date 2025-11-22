using Microsoft.AspNetCore.Mvc;

namespace SupllyHub.API.Controllers;

[ApiController]
public abstract class MainController : ControllerBase
{
    protected ActionResult CustomResponse(object result = null)
    {
        if (OperationIsValid())
        {
            return Ok(value: new
            {
                success = true,
                data = result
            });
        }
        return BadRequest(new
        {
            success = false,
            errors = GetErrors()
        });
    }

    public bool OperationIsValid()
    {
        return true;
    }

    protected string GetErrors()
    {
        return string.Empty;
    }
}
