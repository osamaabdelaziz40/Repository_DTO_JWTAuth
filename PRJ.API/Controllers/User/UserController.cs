using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PRJ.Service.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PRJ.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Route("GetUsers")]
        public async Task<IActionResult> GetUsers(long RoleId)
        {
            return Ok(await _userService.GetUsers(RoleId));
        }

        //[HttpGet]
        //[Route("GetUser")]
        //public async Task<IActionResult> GetUser(long UserId)
        //{
        //    return Ok(await _userService.GetUser(UserId));
        //}

        [HttpGet]
        [Route("GetOrganisationUsers")]
        public async Task<IActionResult> GetOrganisationUsers(long OrganisationId, long RoledId)
        {
            return Ok(await _userService.GetOrganisationUsers(OrganisationId, RoledId));
        }
    }
}
