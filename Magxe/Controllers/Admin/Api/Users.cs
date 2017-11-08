using System.Collections.Generic;
using System.Linq;
using Magxe.Dao;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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