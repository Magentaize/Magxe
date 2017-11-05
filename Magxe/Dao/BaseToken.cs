using System;
using System.ComponentModel.DataAnnotations;

namespace Magxe.Dao
{
    public class BaseToken : IdItem
    {
        [StringLength(200)]
        public string Token { get; set; }
        public string UserId { get; set; }
        public string ClientId { get; set; }
        public DateTime Expires { get; set; }

        public Client Client { get; set; }
        public User User { get; set; }
    }
}