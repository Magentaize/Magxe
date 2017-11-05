using IdentityServer4.Hosting;
using Magxe.Controllers.ActionResults;
using Magxe.Controllers.Admin.Models;
using Magxe.Dao;
using Magxe.Dao.Setting;
using Magxe.Utils;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Magxe.Controllers.Admin.Api
{
    [AdminApiController]
    public class AuthenticationController : Controller
    {
        private readonly DataContext _dataContext;
        private readonly IServiceProvider _services;
        private readonly IPasswordHasher<User> _passwordHasher;

        public AuthenticationController(IServiceProvider services, DataContext dataContext, IPasswordHasher<User> passwordHasher)
        {
            _services = services;
            _dataContext = dataContext;
            _passwordHasher = passwordHasher;
        }

        #region Private

        private async Task<bool> CheckSetupAsync()
        {
            var count = await _dataContext.Users.CountAsync();
            switch (count)
            {
                case 0:
                    return false;
                case 1:
                    var u = await _dataContext.Users.FirstAsync(r => true);
                    return u.Status != UserStatus.InActive;
                default: return true;
            }
        }

        private async Task<IsSetupItem> IsSetup()
        {
            return new IsSetupItem() { Status = await CheckSetupAsync() };
        }

        #endregion

        [Route("setup")]
        [HttpGet]
        public async Task<JsonResult> IsSetupGet()
        {
            return Json(new
            {
                setup = new List<IsSetupItem>()
                {
                    await IsSetup()
                }
            });
        }

        [Route("setup")]
        [HttpPost]
        public async Task<IActionResult> Setup([FromBody] SetupPost setupDetails)
        {
            async Task<IActionResult> AssertSetupCompletedAsync(bool status)
            {
                var isSetup = await CheckSetupAsync();
                if (isSetup == status)
                {
                    return Ok();
                }

                if (isSetup)
                {
                    return new NoPermissionErrorResult("errors.api.authentication.setupAlreadyCompleted");
                }
                else
                {
                    return new NoPermissionErrorResult("errors.api.authentication.setupMustBeCompleted");
                }
            }

            async Task<IActionResult> SetupTasksAsync(SetupPostItem setupData)
            {
                if (setupData.Password.Length < 10)
                {
                    return new ValidationErrorResult("errors.models.user.passwordDoesNotComplyLength",
                        new Dictionary<string, string>() { { "minLength", "10" } });
                }

                _dataContext.Users.RemoveRange(_dataContext.Users);

                var owner = new User()
                {
                    Name = setupData.Name,
                    Slug = Slug.Slugify(setupData.Name),
                    Email = setupData.Email,
                    Status = UserStatus.Active,
                    CreatedTime = DateTime.Now,
                    LastSeen = DateTime.Now,
                };
                owner.Password = _passwordHasher.HashPassword(owner, setupData.Password);
                var blogUpdate = new List<object>()
                {
                    new SettingItem()
                    {
                        Id = Key.Title,
                        Value = setupData.BlogTitle.Trim()
                    },
                    new SettingItem()
                    {
                        Id = Key.Description,
                        Value ="common.api.authentication.sampleBlogDescription"
                    }
                };

                await _dataContext.Users.AddAsync(owner);
                _dataContext.UpdateRange(blogUpdate);
                await _dataContext.SaveChangesAsync();

                return Ok();
            }

            async Task<IActionResult> DoSettingsAsync()
            {
                return Json(await _dataContext.Users.FirstAsync(u => true));
            }

            var data = setupDetails.Setup[0];

            var tResult = await AssertSetupCompletedAsync(false);
            if (!(tResult is OkResult))
                return tResult;

            tResult = await SetupTasksAsync(data);
            if (!(tResult is OkResult))
                return tResult;

            return await DoSettingsAsync();
        }

        [Route("token")]
        [HttpPost]
        public async Task Token()
        {
            var type = typeof(IdentityServer4.IdentityServerConstants).Assembly.GetTypes().First(t => t.Name == "TokenEndpoint");
            var to = _services.GetService(type);
            var method = type.GetMethod("ProcessAsync");
            var iEndpointResult = await (Task<IEndpointResult>)method.Invoke(to, new object[] { HttpContext });

            await iEndpointResult.ExecuteAsync(HttpContext);
        }
    }
}