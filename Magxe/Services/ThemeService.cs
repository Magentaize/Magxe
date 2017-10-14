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

            SetCurrentThemePath();
        }

        internal string CurrentTheme
        {
            get => _dataContext.Settings.First(s => s.Id == Key.Theme).Value;
            set
            {
                var t = _dataContext.Settings.First(s => s.Id == Key.Theme);
                t.Value = value;
                _dataContext.Update(t);
                _dataContext.SaveChanges();
                RaiseThemeChanged(this, value);
            }
        }

        internal void RaiseThemeChanged(object sender, string value)
        {
            SetCurrentThemePath();
            ThemeChanged(sender, value);
        }

        internal void SetCurrentThemePath()
        {
            CurrentThemePath = Path.Combine(_hostingEnvironment.WebRootPath, "themes", CurrentTheme);
        }

        internal string CurrentThemePath { get; private set; }
    }
}