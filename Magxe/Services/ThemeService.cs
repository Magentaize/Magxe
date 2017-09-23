using System.Linq;
using Magxe.Data;

namespace Magxe.Services
{
    public class ThemeService
    {
        private readonly DataContext _dataContext;

        public ThemeService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        internal string CurrentTheme
        {
            get => _dataContext.Settings.First(s => s.Id == Setting.Key.Theme).Value;
            set
            {
                var t = _dataContext.Settings.First(s => s.Id == Setting.Key.Theme);
                t.Value = value;
                _dataContext.Update(t);
                //_dataContext.Settings.First(s => s.Id == Setting.Key.Theme).Value = value;
                _dataContext.SaveChangesAsync();

            }
        }
    }
}