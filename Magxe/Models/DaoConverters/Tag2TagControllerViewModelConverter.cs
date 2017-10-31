using AutoMapper;
using Magxe.Dao;
using System;
using Magxe.Models.ControllerViewModels;

namespace Magxe.Models.DaoConverters
{
    internal class Tag2TagControllerViewModelConverter : ITypeConverter<Tag, TagControllerViewModel>
    {
        public TagControllerViewModel Convert(Tag source, TagControllerViewModel destination, ResolutionContext context)
        {
            return new TagControllerViewModel()
            {
                //tag =  new TagControllerViewModel.TagViewModel() { feature_image = source.FeatureImage},
                date = DateTime.Now,
                name = source.Name,
                description =  source.Description,
                slug = source.Slug,
            };
        }
    }
}