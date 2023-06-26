using System.Security.Claims;
using API.Dtos;
using API.Errors;
using Core.Entities.Identity;
using Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
	public class AccountController : BaseApiController
	{
		private readonly UserManager<AppUser> _userManager;
		private readonly SignInManager<AppUser> _signInManager;
		private readonly ITokenService _tokenService;
		public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager
			, ITokenService tokenService)
		{
			_tokenService = tokenService;
			_signInManager = signInManager;
			_userManager = userManager;
		}

		[Authorize]
		[HttpGet]
		public async Task<ActionResult<UserDto>> GetCurrentUser()
		{
			var username = User.FindFirstValue(ClaimTypes.Name);

			var user = await _userManager.FindByNameAsync(username);

			return new UserDto
			{
				Name = user.UserName,
				Token = _tokenService.CreateToken(user)
			};
		}

		[HttpPost("login")]
		public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
		{
			var user = await _userManager.FindByNameAsync(loginDto.Name);

			if (user == null) return Unauthorized(new ApiResponse(401));

			var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);

			if (!result.Succeeded) return Unauthorized(new ApiResponse(401));

			return new UserDto
			{
				Name = user.UserName,
				Token = _tokenService.CreateToken(user)
			};
		}

		[HttpPost("register")]
		public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
		{
			if (CheckUserExistsAsync(registerDto.Name).Result.Value)
			{
				return new BadRequestObjectResult(new ApiValidationErrorResponse
				{
					Errors = new[] { "Имя пользователя занято" }
				});
			}
			
			var user = new AppUser
			{
				UserName = registerDto.Name,
			};

			var result = await _userManager.CreateAsync(user, registerDto.Password);

			if (!result.Succeeded) return BadRequest(new ApiResponse(400));

			return new UserDto
			{
				Name = user.UserName,
				Token = _tokenService.CreateToken(user)
			};
		}

		[HttpGet("userexists")]
		public async Task<ActionResult<bool>> CheckUserExistsAsync([FromQuery] string username)
		{
			return await _userManager.FindByNameAsync(username) != null;
		}
	}
}