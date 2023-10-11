using API.Dto;
using API.Tools;
using Bll;
using DAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IService _userService;
        private readonly TokenGenerator _tokenGenerator;
        public UserController(IService userService, TokenGenerator tokenGenerator)
        {
            _userService = userService;
            _tokenGenerator = tokenGenerator;
        }

        //[Authorize("ModoPolicy")]
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_userService.GetUsers());
        }

        //[Authorize("AdminPolicy")]
        [HttpPatch("setRole")]
        public IActionResult ChangeRole(ChangerRole r)
        {
            _userService.SetRole(r.UserId, r.RoleId);
            return Ok();
        }

        [HttpPost("login")]
        public IActionResult Login(UserLogin user)
        {
            try
            {
                UserModel connectedUser = _userService.LoginUser(user.Email, user.Psswd);
                return Ok(_tokenGenerator.GenerateToken(connectedUser));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("register")]
        public IActionResult Register(NewUser user)
        {
            _userService.RegisterUser(user.LastName, user.FirstName, user.Nickname, user.Email, user.Psswd);
            return Ok();
        }
    }
}
