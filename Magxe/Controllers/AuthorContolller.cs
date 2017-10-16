using System.Threading.Tasks;
using Magxe.Data;
using Magxe.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;

namespace Magxe.Controllers
{
    [Route("author/{slug}")]
    public class AuthorContolller : Controller
    {
        private readonly DataContext _dataContext;

        public AuthorContolller(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<IActionResult> Index(string slug)
        {
            var author = await _dataContext.Users.FirstOrDefaultAsync(row => row.Slug == slug);
            ViewData["key"] = "author";
            ViewData["author"] = new
            {
                controllerType = ControllerType.Author,
                author
            };

            return View("author");
        }
    }
}