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
            Mapper = new Lazy<IMapper>(() => Config.ServiceProvider.GetService<IMapper>());
        }

        public static async Task<TDestination> MapAsync<TSource, TDestination>(this Task<TSource> source)
        {
            return await source.ContinueWith(innerSource => Mapper.Value.Map<TSource, TDestination>(innerSource.Result));
        }

        public static async Task<TDestination> MapAsync<TSource, TDestination>(this TSource source)
        {
            return await Task.Run(() => Mapper.Value.Map<TSource, TDestination>(source));
        }
    }
}