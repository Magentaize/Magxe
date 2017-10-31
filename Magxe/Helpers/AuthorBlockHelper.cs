using HandlebarsDotNet;
using HandlebarsDotNet.ViewEngine.Abstractions;
using Magxe.Controllers;
using Magxe.Dao;
using Magxe.Extensions;
using Magxe.Models;
using Magxe.Views.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Magxe.Helpers
{
    public class AuthorBlockHelper : HandlebarsBaseHelper
    {
        private readonly DataContext _dataContext;

        public AuthorBlockHelper(DataContext dataContext) : base("author", HelperType.HandlebarsBlockHelper)
        {
            _dataContext = dataContext;
        }

        public override void HandlebarsBlockHelper(TextWriter output, HelperOptions options, dynamic context, params object[] arguments)
        {
            var controllerType = ((IControllerType)context).ControllerType;
            object vm = null;
            switch (controllerType)
            {
                case ControllerType.Post:
                    var authorId = ((IAuthor)context).AuthorId;
                    vm = GetPostControllerAuthorAsync(authorId).Result;
                    break;
                case ControllerType.Author:
                    vm = context;
                    break;
                default: throw new ArgumentOutOfRangeException();
            }

            options.Template(output, vm);
        }

        private async Task<object> GetPostControllerAuthorAsync(string id)
        {
            var author = await _dataContext.Users.FirstAsync(u => u.Id == id);
            return await author.MapAsync<User, PostAuthorViewModel>();
        }
    }
}