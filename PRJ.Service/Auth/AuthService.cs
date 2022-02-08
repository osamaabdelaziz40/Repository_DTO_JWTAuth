using AutoMapper;
using PRJ.Repository;
using PRJ.Repository.Entity;
using PRJ.Service.Auth.Dtos;
using PRJ.Service.RSA;
using PRJ.Utility;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PRJ.Service.Auth
{
    public class AuthService : IAuthService
    {
        //private readonly IRepository<SYS_Login> _loginRepository;
        private readonly IMapper _mapper;
        private readonly IRsaHelper _rsaHelper;
        public AuthService(IMapper mapper, IRsaHelper rsaHelper)
        {
            _mapper = mapper;
            _rsaHelper = rsaHelper;
        }

        public OutputDTO<AuthResponseDto> Login(AuthRequestDto dto)
        {
            //Here we can request to our _loginRepository for Database handshake
            // But we're using dummy authentication within code.
            try
            {
                var password = _rsaHelper.Decrypt(dto.Password);
                if (dto.UserName.Equals("Amwal") && password.Equals("amwal123"))
                {
                    return Output.Handler<AuthResponseDto>(ResponseMessagesCode.GET, new AuthResponseDto() { UserId = 1, UserName = "Amwal", RoleId = 1 });
                }
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
                return null;
            }

            return Output.Handler<AuthResponseDto>(ResponseMessagesCode.NOT_FOUND, null);
        }
    }
}
