using Magxe.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Magxe.Dao.Extensions
{
    internal static class ServiceCollectionExtension
    {
        public static IServiceCollection AddDataContext(this IServiceCollection services)
        {
            services.AddDbContext<DataContext>(options =>
                {
                    options.UseMySql(GlobalVariables.Config.ConnectionString);
                })
                .AddTransient<UserRepository>()
                ;

            return services;
        }
    }
}