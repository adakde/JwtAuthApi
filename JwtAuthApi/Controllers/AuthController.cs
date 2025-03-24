// AuthController.cs
using JwtAuthApi.Entity;
using JwtAuthApi.Models;
using JwtAuthApi.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JwtAuthApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("Register")]
        public async Task<ActionResult<User>> Register(UserDto dto)
        {
            var user = await _authService.RegisterAsync(dto);
            if (user == null)
            {
                return BadRequest("User already exists");
            }
            if (dto.Password.Length < 8)
            {
                return BadRequest("Password must be at least 8 characters long");
            }
            if(dto.Username.Length < 6)
            {
                return BadRequest("Username must be at least 6 characters long");
            }

            return Ok(user);
        }

        [HttpPost("Login")]
        public async Task<ActionResult<TokenResponseDto>> Login(UserDto dto)
        {
            var result = await _authService.LoginAsync(dto);
            if (result == null)
            {
                return BadRequest("User or password is wrong");
            }

            return Ok(result);
        }
        [HttpPost("RefreshToken")]
        public async Task<ActionResult<TokenResponseDto>> RefreshToken(RefreshTokenRequestDto dto)
        {
            var result = await _authService.RefreshTokensAsync(dto);
            if (result == null || result.AccessToken == null || result.RefreshToken == null)
            {
                return BadRequest("Invalid refresh token");
            }

            return Ok(result);
        }

        [Authorize]
        [HttpGet]
        public IActionResult AuthenticatedOnlyEndpoint()
        {
            return Ok("You are authenticated");
        }
        [Authorize]
        [HttpGet("user-info")]
        public IActionResult GetUserInfo()
        {
            var claims = User.Claims.Select(c => new { c.Type, c.Value });
            return Ok(claims);
        }
        [Authorize(Roles = "Admin")]
        [HttpGet("admin-only")]
        public IActionResult AdminOnlyEndpoint()
        {
            return Ok("Only admins can see this");
        }
    }
}