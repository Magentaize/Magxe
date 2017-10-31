using AutoMapper;
using Magxe.Dao;
using Magxe.Extensions;

namespace Magxe.Models.DaoConverters
{
    internal class Post2PostViewModelConverter : ITypeConverter<Post, PostViewModel>
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
                slug = source.Slug,
                date = source.UpdatedTime,
                CustomExcerpt = source.CustomExcerpt,
                Html = source.Html,
                author = _dataContext.Users.GetUserByIdAsync(source.AuthorId).MapAsync<User, PostAuthorViewModel>()
                    .Result,
                tags = _dataContext.PostTags.GetTagsByPostId(source.Id),
            };
        }
    }
}