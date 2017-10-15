using AutoMapper;
using Magxe.Data;
using Magxe.Extensions;

namespace Magxe.Models.DaoConverters
{
    internal class Page2PageViewModelConverter : ITypeConverter<Page, PageViewModel>
    {
        private readonly DataContext _dataContext;

        public Page2PageViewModelConverter(DataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
        }

        public PageViewModel Convert(Page source, PageViewModel destination, ResolutionContext context)
        {
            return new PageViewModel()
            {
                blog = _dataContext.Settings.GetBlogViewModelAsync().Result,
                content = source.Html,
                feature_image = source.FeatureImage,
                title = source.Title,
                slug = source.Slug
            };
        }
    }
}