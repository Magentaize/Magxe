using Microsoft.AspNetCore.Mvc;

namespace Magxe.Controllers.Admin.Api
{
    [AdminApiController]
    public class UsersController
    {
        [HttpGet]
        public IActionResult Me()
        {
            return null;
        }
    }
}