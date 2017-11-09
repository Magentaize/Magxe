using Magxe.Dao;
using Microsoft.Extensions.DependencyInjection;

namespace Magxe.Repositories
{
    internal class BaseRepository
    {
        protected DataContext DbContext { get; }

        public BaseRepository()
        {
            DbContext = GlobalVariables.ServiceProvider.GetService<DataContext>();
        }
    }
}