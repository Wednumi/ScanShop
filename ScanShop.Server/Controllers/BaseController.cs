using Microsoft.AspNetCore.Mvc;
using ScanShop.Shared.Result;

namespace ScanShop.Server.Controllers
{
    public class BaseController : ControllerBase
    {
        protected ActionResult FromFeatureResult(FeatureResult result)
        {
            if (result.Success)
            {
                return Ok();
            }
            if(result.UserErrors.Any())
            {
                return BadRequest(result);
            }
            return StatusCode(StatusCodes.Status500InternalServerError, result);
        }
    }
}
