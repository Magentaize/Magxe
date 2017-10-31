//using System;
//using Magxe.Dao;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net.Http;
//using System.Threading.Tasks;
//using IdentityServer4.Hosting;
//using Magxe.Controllers.ActionResults;
//using Magxe.Controllers.Admin.Models;
//using Magxe.Controllers.Errors;
//using Magxe.Controllers.Errors;
//using Magxe.Dao.DbContext;
//using Magxe.Dao.Enums;
//using Magxe.Dao.Setting;
//using UserStatus = Magxe.Identity.UserStatus;

//namespace Magxe.Controllers.Admin.Api
//{
//    [AdminApiRoute]
//    public class Authentication : Controller
//    {
//        private readonly DataContext _dataContext;
//        private readonly IServiceProvider _services;

//        public Authentication(IServiceProvider services,t dataContext)
//        {
//            _services = services;
//            _dataContext = dataContext;
//        }

//        #region Private

//        private async Task<bool> CheckSetupAsync()
//        {
//            return await _dataContext.Users.CountAsync() != 0;
//        }

//        private async Task<IsSetupItem> IsSetup()
//        {
//            return new IsSetupItem() {Status = await CheckSetupAsync() };
//        }

//        #endregion

//        [Route("setup")]
//        [HttpGet]
//        public async Task<JsonResult> IsSetupGet()
//        {
//            return Json(new
//            {
//                setup = new List<IsSetupItem>()
//                {
//                    await IsSetup()
//                }
//            });
//        }

//        [Route("setup")]
//        [HttpPost]
//        public async Task<IActionResult> Setup([FromBody] SetupPost setupDetails)
//        {
//            async Task<IActionResult> AssertSetupCompletedAsync(bool status)
//            {
//                var isSetup = await CheckSetupAsync();
//                if (isSetup == status)
//                {
//                    return Ok();
//                }

//                if (isSetup)
//                {
//                    return new NoPermissionErrorResult("errors.api.authentication.setupAlreadyCompleted");
//                }
//                else
//                {
//                    return new NoPermissionErrorResult("errors.api.authentication.setupMustBeCompleted");
//                }
//            }

//            async Task<IActionResult> SetupTasksAsync(SetupPostItem setupData)
//            {
//                if (setupData.Password.Length <= 10)
//                {
//                    return new ValidationErrorResult("errors.models.user.passwordDoesNotComplyLength",
//                        new Dictionary<string, string>() { { "minLength", "10" } });
//                }

//                var owner = new IdentityUser()
//                {
//                    Id = 1,
//                    Name = setupData.Name,
//                    Slug = Slug.Slugify(setupData.Name),
//                    Email = setupData.Email,
//                    Password = setupData.Password,
//                    Status = UserStatus.Active,
//                    CreatedTime = DateTime.Now,
//                    LastLog = DateTime.Now,
//                };
//                var blogUpdate = new List<object>()
//                {
//                    new SettingItem()
//                    {
//                        Id = Key.Title,
//                        Value = setupData.BlogTitle.Trim()
//                    },
//                    new SettingItem()
//                    {
//                        Id = Key.Description,
//                        Value ="common.api.authentication.sampleBlogDescription"
//                    }
//                };

//                await _dataContext.Users.AddAsync(owner);
//                _dataContext.UpdateRange(blogUpdate);
//                await _dataContext.SaveChangesAsync();

//                return Ok();
//            }

//            async Task<IActionResult> DoSettingsAsync()
//            {
//                return Json(await _dataContext.Users.FirstAsync(u => u.Id == 1));
//            }

//            var data = setupDetails.Setup[0];

//            var tResult = await AssertSetupCompletedAsync(false);
//            if (!(tResult is OkResult))
//                return tResult;

//            tResult = await SetupTasksAsync(data);
//            if (!(tResult is OkResult))
//                return tResult;

//            return await DoSettingsAsync();
//        }

//        [Route("token")]
//        [HttpPost]
//        public async Task Token()
//        {
//            var type = typeof(IdentityServer4.IdentityServerConstants).Assembly.GetTypes().First(t => t.Name == "TokenEndpoint");
//            var to = _services.GetService(type);
//            var method = type.GetMethod("ProcessAsync");
//            var iEndpointResult = await (Task<IEndpointResult>)method.Invoke(to, new object[] { HttpContext });

//            await iEndpointResult.ExecuteAsync(HttpContext);
//        }
//    }
//}