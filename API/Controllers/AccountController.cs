using API.Dtos;
using API.Errors;
using Core.Interfaces;
using Core.Models.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ITokenService _tokenService;

        public AccountController(UserManager<ApplicationUser> userManager , ITokenService tokenService)
        {
            _userManager = userManager;
            _tokenService = tokenService;
        }
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<UserDto>> GetUser()
        {
            var Email = HttpContext.User.Claims?.FirstOrDefault(x=>x.Type == ClaimTypes.Email)?.Value;
            var user = await _userManager.FindByEmailAsync(Email);
            return new UserDto
            {
                Email = user.Email,
                DisplayName = user.UserName,
                Token = _tokenService.CreateToken(user)
            };
        }
        [HttpPost("Login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            var user = await _userManager.FindByEmailAsync(loginDto.Email);
            if (user == null)
            {
                return Unauthorized(new ApiResponse(401));
            }
            var result = await _userManager.CheckPasswordAsync(user, loginDto.Password);
            if (result == false)
            {
                return Unauthorized(new ApiResponse(401));
            }
            return new UserDto { Email = loginDto.Email, DisplayName = user.UserName, Token = _tokenService.CreateToken(user) };
        }
        [HttpPost("Register")]
        public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
        {
            var exist = await _userManager.FindByEmailAsync(registerDto.Email);
            if (exist != null)
            {
                return new BadRequestObjectResult(new ApiResponse(400, "Email already used."));
            }

            var user = new ApplicationUser
            {
                Email = registerDto.Email,
                UserName = registerDto.UserName
            };
            var result =await _userManager.CreateAsync(user,registerDto.Password);
            if (!result.Succeeded)
            {
                return BadRequest(new ApiResponse(400,result.Errors.ToString()));
            }
            return new UserDto
            {
                  Email = user.Email,
                  DisplayName = user.UserName,
                  Token = _tokenService.CreateToken(user)
            };
        }
        [HttpPut]
        [Authorize]
        public async Task<ActionResult<UpdateUserDto>> UpdateUserInfo (UpdateUserDto updateUserDto)
        {
            var email = User?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value;
            var user = await _userManager.FindByEmailAsync(email);
            user.Address1 = updateUserDto.Address1;
            user.Address2 = updateUserDto.Address2;
            user.City = updateUserDto.City;
            user.Street = updateUserDto.Street;
            user.FName = updateUserDto.FName;
            user.LName = updateUserDto.LName;
            user.State = updateUserDto.State;
            user.PhoneNumber = updateUserDto.Phone;
            user.ZipCode = updateUserDto.ZipCode;
            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
            {
                return BadRequest(new ApiResponse(400));
            }
            return updateUserDto;
        }

    }
}
