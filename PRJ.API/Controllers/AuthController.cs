using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PRJ.Service.Auth;
using PRJ.Service.Auth.Dtos;
using PRJ.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PRJ.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IAuthService _authService;
        public AuthController(IConfiguration configuration, IAuthService authService)
        {
            _configuration = configuration;
            _authService = authService;
        }

        [HttpPost]
        [Route("post")]
        [AllowAnonymous]
        public IActionResult Login([FromBody] AuthRequestDto request)
        {
            var result = _authService.Login(request);
            if (!(result is null) && result.Succeeded)
            {
                string token = string.Empty;
                token = JWT.JWT.GenerateJwtToken(new SessionDTO
                {
                    UserId = result.Data.UserId,
                    RoleId = (int)RoleEnums.Employee,
                    Username = result.Data.UserName,
                }, _configuration);

                result.Data.Token = token;
                return Ok(new OutputDTO<string>() { Data = token, HttpStatusCode = 200, Message = "Success", Succeeded = true });
            }
            return Ok(result);
        }
    }
}
