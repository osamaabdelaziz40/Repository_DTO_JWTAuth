using PRJ.Service.Auth.Dtos;
using PRJ.Utility;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PRJ.Service.Auth
{
    public interface IAuthService
    {
        OutputDTO<AuthResponseDto> Login(AuthRequestDto request);
    }
}
