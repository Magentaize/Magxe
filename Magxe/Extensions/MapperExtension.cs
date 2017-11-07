using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace Magxe.Extensions
{
    internal static class MapperExtension
    {
        private static readonly Lazy<IMapper> Mapper;

        static MapperExtension()
        {
            Mapper = new Lazy<IMapper>(() => GlobalVariables.ServiceProvider.GetService<IMapper>());
        }

        public static async Task<TDestination> MapAsync<TSource, TDestination>(this Task<TSource> source)
        {
            return Mapper.Value.Map<TSource, TDestination>(await source);
        }

        public static async Task<TDestination> MapAsync<TSource, TDestination>(this TSource source)
        {
            return await Task.Run(() => Mapper.Value.Map<TSource, TDestination>(source));
        }
    }
}