using System;
using System.Collections.Generic;

namespace Magxe.Dao
{
    public class User : IdentityUser
    {
        public User()
        {
            Id = Guid.NewGuid().ToString("N");
            AccessTokens = new HashSet<AccessToken>();
            RefreshTokens = new HashSet<RefreshToken>();
        }

        public ICollection<AccessToken> AccessTokens { get; set; }
        public ICollection<RefreshToken> RefreshTokens { get; set; }
    }
}