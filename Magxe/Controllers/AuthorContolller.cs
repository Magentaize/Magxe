using System.Threading.Tasks;
using Magxe.Data;
using Magxe.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;

namespace Magxe.Controllers
{
    [Route("author/{name}")]
    public class AuthorContolller : Controller
    {
        private readonly DataContext _dataContext;

        public AuthorContolller(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<IActionResult> Index()
        {
            var authorName = HttpContext.GetRouteValue("name").Cast<string>();
            var author = await _dataContext.Users.FirstOrDefaultAsync(row => row.Name == authorName);
            ViewData["key"] = "author";
            ViewData["author"] = new
            {
                controllerType = ControllerType.Author,
                authorId = author.Id 

            };

            return View("author");
        }
    }
}