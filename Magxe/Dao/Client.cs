using System.Collections.Generic;

namespace Magxe.Dao
{
    public class Client : IdItem
    {
        public Client()
        {
            AccessTokens = new HashSet<AccessToken>();
            RefreshTokens = new HashSet<RefreshToken>();
        }

        public string Name { get; set; }
        public string Slug { get; set; }
        public string Secret { get; set; }

        public ICollection<AccessToken> AccessTokens { get; set; }
        public ICollection<RefreshToken> RefreshTokens { get; set; }
    }
}