using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace Magxe.Dao
{
    [Table("Users_Roles")]
    public class UserRole
    {
        public string UserId { get; set; }
        public User User { get; set; }

        public string RoleId { get; set; }
        public Role Role { get; set; }
    }
}