using AutoMapper;
using Magxe.Data;

namespace Magxe.Models.DaoConverters
{
    internal static class DaoConverters
    {
        public static void ConfigAutoMapper(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<User, AuthorViewModel>().ConvertUsing<User2AuthorViewModelConverter>();
            cfg.CreateMap<Post,PostViewModel>().ConvertUsing<Post2PostViewModelConverter>();
        }
    }
}