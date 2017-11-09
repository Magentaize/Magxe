using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using Magxe.Dao;
using Magxe.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http;
using Microsoft.EntityFrameworkCore;

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

            var me = _dbContext.Users.First(r => true);

            IEnumerable<IdentityRole> roles;
            if (!string.IsNullOrEmpty(Request.Query["include"][0]))
            {
                var roleId = _dbContext.UserRoles.First(r => r.UserId == me.Id).RoleId;
                roles = _dbContext.Roles.Where(r => r.Id == roleId);
            }
            else
            {
                roles = new List<IdentityRole>();
            }

            return Json(new
            {
                Users = new object[]
                {
                    new
                    {
                        Id = me.Id,
                        Name = me.Name,
                        Slug = me.Slug,
                        Email = me.Email,
                        Profile_image = me.ProfileImage,
                        Roles = roles,
                    }, 
                },
            });
        }
    }
}