using AutoMapper;
using Magxe.Data;
using Magxe.Extensions;

namespace Magxe.Models.DaoConverters
{
    public class Post2PostViewModelConverter : ITypeConverter<Post, PostViewModel>
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
                AuthorId = source.AuthorId,
                blog = _dataContext.Settings.GetBlogViewModelAsync().Result,
                content = source.Html,
                feature_image = source.FeatureImage,
                tags = _dataContext.Tags.GetTagsByIds(source.Tags),
                title = source.Title,
                url = source.Slug
            };
        }
    }
}