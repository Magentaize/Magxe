using System;
using System.Collections.Generic;

namespace Magxe.Dao
{
    public class User : IdentityUser
    {
        public User()
        {
            Id = Guid.NewGuid().ToString("N");
            RefreshTokens = new HashSet<RefreshToken>();
        }

        public ICollection<RefreshToken> RefreshTokens { get; set; }
    }
}