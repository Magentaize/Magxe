using Magxe.Dao;
using Magxe.Dao.Setting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace Magxe.Controllers.Admin.Api
{
    [AdminApiController]
    public class SettingsController : Controller
    {
        private readonly DataContext _dbContext;

        public SettingsController(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes=JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult Index()
        {
            var sb = new StringBuilder();
            var values = new List<SettingItem>();
            var paramc = Request.Query["type"][0].Split(',');
            foreach (var param in paramc)
            {
                var dict = _dbContext.Settings.Where(r => r.Type == param);
                foreach (var settingItem in dict)
                {
                    values.Add(settingItem);
                }
                sb.Append($"{param},");
            }

            sb.Remove(sb.Length - 1, 1);

            return Json(new
            {
                settings = values,
                meta = new
                {
                    filters = new
                    {
                        type = sb.ToString()
                    }
                }
            });
        }
    }
}