using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace Magxe.Admin.Controllers
{
    [Route("admin")]
    public class IndexController : Controller
    {
        public string Index()
        {
            return "admin";
        }
    }
}