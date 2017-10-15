using AutoMapper;
using Magxe.Data;
using Magxe.Extensions;

namespace Magxe.Models.DaoConverters
{
    internal class Post2IndexPostViewModelConverter : ITypeConverter<Post,IndexPostViewModel>
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;

        public Post2IndexPostViewModelConverter(DataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public IndexPostViewModel Convert(Post source, IndexPostViewModel destination, ResolutionContext context)
        {
            return new IndexPostViewModel()
            {
                title = source.Title,
                url =  source.Slug,
                date = source.UpdatedTime,
                author = _mapper.Map<User, PostAuthorViewModel>(_dataContext.Users.GetUserByIdAsync(source.AuthorId).Result),
                tags = _dataContext.Tags.GetTagsByIds(source.Tags),
                CustomExcerpt = source.CustomExcerpt,
                Html = source.Html
            };
        }
    }
}