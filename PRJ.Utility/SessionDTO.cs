using System;
using System.Collections.Generic;
using System.Text;

namespace PRJ.Utility
{
    public class SessionDTO
    {
        public long UserId { get; set; }
        public int RoleId { get; set; }
        public string Username { get; set; }
        public string Timezone { get; set; }
    }
}
