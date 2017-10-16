using AutoMapper;
using Magxe.Data;
using Magxe.Extensions;

namespace Magxe.Models.DaoConverters
{
    internal class Post2PostViewModelConverter : ITypeConverter<Post,PostViewModel>
    {
        private readonly DataContext _dataContext;

        public Post2PostViewModelConverter(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public PostViewModel Convert(Post source, PostViewModel destination, ResolutionContext context)
        {
            return new PostViewModel()
            {
                title = source.Title,
                slug =  source.Slug,
                date = source.UpdatedTime,
                author = _dataContext.Users.GetUserByIdAsync(source.AuthorId).MapAsync<User, PostAuthorViewModel>().Result,
                tags = _dataContext.Tags.GetTagsByIds(source.Tags),
                CustomExcerpt = source.CustomExcerpt,
                Html = source.Html
            };
        }
    }
}