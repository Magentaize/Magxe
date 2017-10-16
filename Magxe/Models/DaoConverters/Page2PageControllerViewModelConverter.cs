using AutoMapper;
using Magxe.Data;
using Magxe.Extensions;
using Magxe.Models.ControllerViewModels;

namespace Magxe.Models.DaoConverters
{
    internal class Page2PageControllerViewModelConverter : ITypeConverter<Page, PageControllerViewModel>
    {
        private readonly DataContext _dataContext;

        public Page2PageControllerViewModelConverter(DataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
        }

        public PageControllerViewModel Convert(Page source, PageControllerViewModel destination, ResolutionContext context)
        {
            return new PageControllerViewModel()
            {
                meta_title = source.MetaTitle.IsNullOrEmpty() ? source.Title : source.MetaTitle,
                blog = _dataContext.Settings.GetBlogViewModelAsync().Result,
                content = source.Html,
                feature_image = source.FeatureImage,
                title = source.Title,
                slug = source.Slug
            };
        }
    }
}