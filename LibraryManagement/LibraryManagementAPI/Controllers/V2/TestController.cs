using LibraryManagementAPI.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementAPI.Controllers.V2
{
    [ApiController]
    [ApiVersion(ApiRoutes.V2)]
    public class TestController: Controller
    {
        [MapToApiVersion(ApiRoutes.V2)]
        [HttpGet]
        [Route(ApiRoutes.Test.TestGet)]
        public IActionResult TestGet()
        {
            return Ok("OK");
        }

        [MapToApiVersion(ApiRoutes.V1)]
        [MapToApiVersion(ApiRoutes.V2)]
        [HttpPost]
        [Route(ApiRoutes.Test.TestPost)]
        public IActionResult TestPost(string data)
        {
            return Ok(data);
        }
    }
}
