using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PRJ.Service.Auth.Dtos
{
    public class AuthRequestDto
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        public string Timezone { get; set; } = string.Empty;
    }
}
