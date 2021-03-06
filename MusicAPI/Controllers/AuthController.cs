using AutoMapper;
using BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ModelsDto.AuthDto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MusicAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthController : ControllerBase
	{
        private IAuthService _authService;
        private readonly IMapper _mapper;

        public AuthController(IAuthService authService, IMapper mapper)
        {
            _authService = authService;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Authenticate([FromBody] UserLoginDto model)
        {

            var user = await _authService.Authenticate(model.Username, model.Password);

            return Ok(new {access_token = user});
        }


        [Authorize]
        [HttpPost("changePassword")]
        public async Task<IActionResult> ChangePassword([FromBody] UserChangePasswordDto model)
        {
            if (!ModelState.IsValid)
            {
                return ValidationProblem();
            }
            var result = await _authService.ChangePassword(model.UserId, model.OldPassword, model.NewPassword);
			if (!result)
			{
                return StatusCode(500);
            }
            return Ok();
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRegisterDto userModel)
        {
            if (!ModelState.IsValid)
            {
                return ValidationProblem();
            }
            var user = _mapper.Map<IdentityUser>(userModel);

            await _authService.Register(user, userModel.Password);

            return Ok();
        }


        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _authService.GetAll();
			if (users == null)
			{
                return NotFound("Users are empty");
			}
            var usersDto = _mapper.Map<IEnumerable<UserDto>>(users);
            return Ok(usersDto);
        }
    }
}
