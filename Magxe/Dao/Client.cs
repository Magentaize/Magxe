using System.Collections.Generic;

namespace Magxe.Dao
{
    public class Client : IdItem
    {
        public Client()
        {
            RefreshTokens = new HashSet<RefreshToken>();
        }

        public string Name { get; set; }
        public string Slug { get; set; }
        public string Secret { get; set; }
        public string Uuid { get; set; }

        public ICollection<RefreshToken> RefreshTokens { get; set; }
    }
}