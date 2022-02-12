using LibraryManagementAPI.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementAPI.Controllers.V1
{
    [ApiController]
    [ApiVersion(ApiRoutes.V1)]
    public class IdentityController : Controller
    {
        [HttpGet]
        [Route(ApiRoutes.Identity.Register)]
        public IActionResult Register()
        {
            return Ok("OK");
        }
    }
}
