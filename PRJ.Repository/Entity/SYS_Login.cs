using System;
using System.Collections.Generic;
using System.Text;

namespace PRJ.Repository.Entity
{
    public partial class SYS_Login
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
