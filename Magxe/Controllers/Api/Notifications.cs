using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace Magxe.Controllers.Api
{
    [RestApiController]
    public class NotificationsController : Controller
    {
        public IActionResult Index()
        {
            return Json(new
            {
                notifications = new object[0]
            });
        }
    }
}