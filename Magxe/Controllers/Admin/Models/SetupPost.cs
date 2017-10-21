using System.Collections.Generic;

namespace Magxe.Controllers.Admin.Models
{
    public class SetupPost
    {
        public List<SetupPostItem> Setup;
    }
    
    public class SetupPostItem
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string BlogTitle { get; set; }
    }
}