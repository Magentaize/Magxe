using System.Collections.Generic;
using System.Threading.Tasks;
using Magxe.Controllers.Admin.Models;
using Magxe.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Magxe.Controllers.Admin.Api
{
    [AdminApiRoute]
    public class Authentication : Controller
    {
        private readonly DataContext _dataContext;

        public Authentication(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [Route("setup")]
        [HttpGet]
        public async Task<JsonResult> SetupGet()
        {
            return Json(new
            {
                setup = new List<SetupGet>()
                {
                    new SetupGet() {Status = await _dataContext.Users.CountAsync() == 0}
                }
            });
        }

        [Route("setup")]
        [HttpPost]
        public async Task<JsonResult> SetupPost([FromBody] SetupPost setup)
        {
            return Json(null);
        }

        [Route("token")]
        [HttpPost]
        public JsonResult Token()
        {
            return Json(null);
        }
    }
}