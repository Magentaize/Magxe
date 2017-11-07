using IdentityServer4.Models;

namespace Magxe.Dao
{
    public class RefreshToken : PersistedGrant
    {
        public Client Client { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
    }
}