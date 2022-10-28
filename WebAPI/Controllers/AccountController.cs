using Core.DTOs;
using Core.Interfaces;
using Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService accountService;

        public AccountController(IAccountService accountService)
        {
            this.accountService = accountService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDTO data)
        {
            if (!ModelState.IsValid) return BadRequest();

            await accountService.RegisterAsync(data);

            return Ok();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO data)
        {
            if (!ModelState.IsValid) return BadRequest();

            var respose = await accountService.LoginAsync(data.Login, data.Password);

            return Ok(respose);
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            await accountService.LogoutAsync();

            return Ok();
        }

        [HttpPost("request-password-reset")]
        public async Task<IActionResult> RequestPasswordReset([FromBody] RequestResetPasswordDTO request)
        {
            await accountService.RequestResetPassword(request.UserEmail);

            return Ok();
        }

        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDTO resetPasswordDTO)
        {
            await accountService.ResetPassword(resetPasswordDTO);

            return Ok();
        }
    }
}
