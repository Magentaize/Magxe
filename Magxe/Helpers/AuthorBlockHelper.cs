using System;
using System.IO;
using System.Threading.Tasks;
using AutoMapper;
using HandlebarsDotNet;
using HandlebarsDotNet.ViewEngine.Abstractions;
using Magxe.Controllers;
using Magxe.Data;
using Magxe.Data.Setting;
using Magxe.Helpers.Abstractions;
using Magxe.Models;
using Microsoft.EntityFrameworkCore;

namespace Magxe.Helpers
{
    public class AuthorBlockHelper : HandlebarsBaseHelper
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;
        private const string _authorPrefix = "/author/";

        public AuthorBlockHelper(DataContext dataContext, IMapper mapper) : base("author", HelperType.HandlebarsBlockHelper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public override void HandlebarsBlockHelper(TextWriter output, HelperOptions options, dynamic context, params object[] arguments)
        {
            var authorId = ((IAuthor)context).AuthorId;
            var controllerType = ((IControllerType)context).ControllerType;
            object vm = null;
            switch (controllerType)
            {
                case ControllerType.Post:
                    vm = GetPostControllerAuthorAsync(authorId).Result;
                    break;
                case ControllerType.Author:
                    vm = GetAuthorControllerAuthorAsync(context).Result;
                    break;
                default: throw new ArgumentOutOfRangeException();
            }

            options.Template(output, vm);
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
                    blog = await _dataContext.Settings.GetBlogModelAsync()
                };
            });

            return obj;
        }

        private async Task<object> GetPostControllerAuthorAsync(int id)
        {
            var author = await _dataContext.Users.FirstAsync(u => u.Id == id);
            return _mapper.Map<User, PostAuthorViewModel>(author);
        }
    }
}