using AutoMapper;
using Magxe.Data;
using Magxe.Data.Setting;
using Magxe.Extensions;

namespace Magxe.Models.DaoConverters
{
    internal class Post2PostViewModelConverter : ITypeConverter<Post,PostViewModel>
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;

        public Post2PostViewModelConverter(DataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public PostViewModel Convert(Post source, PostViewModel destination, ResolutionContext context)
        {
            return new PostViewModel()
            {
                title = source.Title,
                url =  source.Slug,
                date = source.UpdatedTime,
                author = _mapper.Map<User, AuthorViewModel>(_dataContext.Users.GetUserByIdAsync(source.AuthorId).Result),
                tags = _dataContext.GetTagsByIds(source.Tags),
                CustomExcerpt = source.CustomExcerpt,
                Html = source.Html
            };
        }
    }
}