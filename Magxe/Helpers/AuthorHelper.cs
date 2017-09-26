using System.IO;
using HandlebarsDotNet;
using HandlebarsDotNet.ViewEngine.Abstractions;
using Magxe.Data;
using Microsoft.EntityFrameworkCore;

namespace Magxe.Helpers
{
    public class AuthorHelper : BaseHelper
    {
        private readonly DataContext _dataContext;

        public AuthorHelper(DataContext dataContext) : base("author", HelperType.HandlebarsBlockHelper)
        {
            _dataContext = dataContext;
        }

        public override void HandlebarsBlockHelper(TextWriter output, HelperOptions options, dynamic context, params object[] arguments)
        {
            var authorId = (int) context.authorId;
            var author = _dataContext.Users.FirstOrDefaultAsync(row => row.Id == authorId).Result;
            var viewData = new
            {
                url = "/",
                profile_image = author.ProfileImage,
                name = author.Name
            };
            options.Template(output, viewData);
        }
    }
}