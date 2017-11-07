using System;

namespace Magxe
{
    internal class ConfigModel
    {
        public bool IsDevelopment { get; set; } = false;
        public ConfigScheme Development { get; set; }
        public ConfigScheme Production { get; set; }
    }

    internal class ConfigScheme
    {
        public Uri Url { get; set; }
        public _Database Database { get; set; }
        public string ConnectionString { get; set; }

        public class _Database
        {
            public string Client { get; set; }
            public _Connection Connection { get; set; }

            public class _Connection
            {
                public string Host { get; set; } = "localhost";
                public int Port { get; set; } = 3306;
                public string User { get; set; } = "root";
                public string Password { get; set; } = string.Empty;
                public string Database { get; set; } = "magxe";
            }
        }
    }
}