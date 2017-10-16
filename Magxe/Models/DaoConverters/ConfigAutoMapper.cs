using AutoMapper;
using Magxe.Data;
using Magxe.Models.ControllerViewModels;

namespace Magxe.Models.DaoConverters
{
    internal static class DaoConverters
    {
        public static void ConfigAutoMapper(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<User, PostAuthorViewModel>().ConvertUsing<User2PostAuthorViewModelConverter>();
            cfg.CreateMap<Post, PostViewModel>().ConvertUsing<Post2PostViewModelConverter>();
            cfg.CreateMap<Page, PageControllerViewModel>().ConvertUsing<Page2PageControllerViewModelConverter>();
            cfg.CreateMap<Post, PostControllerViewModel>().ConvertUsing<Post2PostControllerViewModelConverter>();
        }
    }
}