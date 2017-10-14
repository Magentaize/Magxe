using System;
using System.IO;
using System.Threading.Tasks;
using HandlebarsDotNet;
using HandlebarsDotNet.ViewEngine.Abstractions;
using Magxe.Controllers;
using Magxe.Data;
using Magxe.Data.Setting;
using Magxe.Models;
using Microsoft.EntityFrameworkCore;

namespace Magxe.Helpers
{
    public class AuthorHelper : HandlebarsBaseHelper
    {
        public AuthorHelper() : base("author", HelperType.HandlebarsHelper)
        {
        }

        public override void HandlebarsHelper(TextWriter output, dynamic context, params object[] arguments)
        {
            var vm = (AuthorViewModel)(context.author);
            output.WriteSafeString($"<a href=\"/author/{vm.url}/\">{vm.name}</a>");
        }
    }

    public class AuthorBlockHelper : HandlebarsBaseHelper
    {
        private readonly DataContext _dataContext;
        private const string _authorPrefix = "/author/";

        public AuthorBlockHelper(DataContext dataContext) : base("author", HelperType.HandlebarsBlockHelper)
        {
            _dataContext = dataContext;
        }

        public override void HandlebarsBlockHelper(TextWriter output, HelperOptions options, dynamic context, params object[] arguments)
        {
            var controllerType = (ControllerType)context.controllerType;
            object viewData = null;
            switch (controllerType)
            {
                case ControllerType.Post:
                    viewData = GetPostControllerAuthorAsync(context).Result;
                    break;
                case ControllerType.Author:
                    viewData = GetAuthorControllerAuthorAsync(context).Result;
                    break;
                default: throw new ArgumentOutOfRangeException();
            }

            options.Template(output, viewData);
        }

        private async Task<object> GetAuthorControllerAuthorAsync(dynamic context)
        {
            AuthorPageAuthorModel obj = null;
            await Task.Run(async () =>
            {
                var authorId = (int)context.author.Id;
                var author = await _dataContext.Users.FirstOrDefaultAsync(row => row.Id == authorId);
                obj = new AuthorPageAuthorModel
                {
                    url = $"{_authorPrefix}{author.Name}",
                    profile_image = author.ProfileImage,
                    name = author.Name,
                    location = author.Location,
                    bio = author.Bio,
                    website = null, //author.Website,
                    blog = await _dataContext.Settings.GetBlogModelAsync()
                };
            });

            return obj;
        }

        private async Task<object> GetPostControllerAuthorAsync(dynamic context)
        {
            AuthorViewModel obj = null;
            await Task.Run(async () =>
            {
                var authorId = (int) context.authorId;
                var author = await _dataContext.Users.FirstOrDefaultAsync(row => row.Id == authorId);
                obj = new AuthorViewModel()
                {
                    url = $"{_authorPrefix}{author.Name}",
                    profile_image = author.ProfileImage,
                    name = author.Name,
                    location = author.Location,
                    bio = author.Bio,
                    website = null //author.Website
                };
            });

            return obj;
        }
    }
}