using AutoMapper;
using Magxe.Data;
using Magxe.Extensions;
using Magxe.Models.ControllerViewModels;

namespace Magxe.Models.DaoConverters
{
    public class Post2PostControllerViewModelConverter : ITypeConverter<Post, PostControllerViewModel>
    {
        private readonly DataContext _dataContext;

        public Post2PostControllerViewModelConverter(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public PostControllerViewModel Convert(Post source, PostControllerViewModel destination, ResolutionContext context)
        {
            return new PostControllerViewModel()
            {
                meta_title = source.MetaTitle.IsNullOrEmpty() ? source.Title : source.MetaTitle,
                blog = _dataContext.Settings.GetBlogViewModelAsync().Result,
                content = source.Html,
                feature_image = source.FeatureImage,
                title = source.Title,
                AuthorId = source.AuthorId,
                tags = _dataContext.PostTags.GetTagsByPostId(source.Id),
                slug = source.Slug
            };
        }
    }
}