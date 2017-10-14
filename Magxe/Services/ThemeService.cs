using System;
using System.IO;
using System.Linq;
using Magxe.Data;
using Magxe.Data.Setting;
using Microsoft.AspNetCore.Hosting;

namespace Magxe.Services
{
    public class ThemeService
    {
        private readonly DataContext _dataContext;
        private readonly IHostingEnvironment _hostingEnvironment;
        public event EventHandler<string> ThemeChanged = delegate{ };

        public ThemeService(DataContext dataContext, IHostingEnvironment hostingEnvironment)
        {
            _dataContext = dataContext;
            _hostingEnvironment = hostingEnvironment;
        }

        internal string CurrentTheme
        {
            get => _dataContext.Settings.First(s => s.Id == Key.Theme).Value;
            set
            {
                var t = _dataContext.Settings.First(s => s.Id == Key.Theme);
                t.Value = value;
                _dataContext.Update(t);
                //_dataContext.Settings.First(s => s.Id == Setting.Key.Theme).Value = value;
                _dataContext.SaveChangesAsync();
                ThemeChanged(this, value);
            }
        }

        internal string CurrentThemePath => Path.Combine(_hostingEnvironment.WebRootPath, "themes", CurrentTheme);
    }
}