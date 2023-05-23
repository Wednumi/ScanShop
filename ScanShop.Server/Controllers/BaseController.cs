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
            if (result.UserErrors is not null && result.UserErrors.Any())
            {
                return BadRequest(result.UserErrors);
            }
            return StatusCode(StatusCodes.Status500InternalServerError, result.ServerErrors);
        }
        protected ActionResult FromFeatureResult<T>(FeatureResult<T> result) where T : class
        {
            if (result.Success)
            {
                return Ok(result.Result);
            }
            if (result.UserErrors is not null && result.UserErrors.Any())
            {
                return BadRequest(result.UserErrors);
            }
            return StatusCode(StatusCodes.Status500InternalServerError, result.ServerErrors);
        }
    }
}
