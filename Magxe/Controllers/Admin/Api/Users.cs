using Magxe.Dao;
using Magxe.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;

namespace Magxe.Controllers.Admin.Api
{
    [AdminApiController]
    public class UsersController : Controller
    {
        private readonly DataContext _dbContext;

        public UsersController(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        [Route("me")]
        [HttpGet]
        [Authorize]
        public IActionResult Me()
        {
            var handler = new JwtSecurityTokenHandler();
            var jwt = handler.ReadToken(HttpContext.Request.Headers.CastTo<FrameRequestHeaders>().HeaderAuthorization.ToString().Substring(7));
            var claims = jwt.CastTo<JwtSecurityToken>().Claims;
            if (claims.FirstOrDefault(r => r.Type == ClaimTypes.Sid) != null)
            {
                
            }

            var me = _dbContext.Users.Include(r=>r.UsersRoles).ThenInclude(r=>r.Role).First(r => true);
            return Json(new
            {
                users = new object[]
                {
                    me
                }
            });
        }
    }
}