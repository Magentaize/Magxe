using AutoMapper;
using Magxe.Data;

namespace Magxe.Models.DaoConverters
{
    internal static class DaoConverters
    {
        public static void ConfigAutoMapper(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<User, PostAuthorViewModel>().ConvertUsing<User2PostAuthorViewModelConverter>();
            cfg.CreateMap<Post,IndexPostViewModel>().ConvertUsing<Post2IndexPostViewModelConverter>();
            cfg.CreateMap<Post,PostViewModel>().ConvertUsing<Post2PostViewModelConverter>();
        }
    }
}