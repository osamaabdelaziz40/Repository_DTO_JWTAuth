using System;
using System.Collections.Generic;
using System.Text;

namespace PRJ.Service.Auth.Dtos
{
    public class AuthResponseDto
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public string UserName { get; set; }
        public string Token { get; set; }
    }
}
