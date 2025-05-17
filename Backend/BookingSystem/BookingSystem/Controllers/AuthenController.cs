using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using BookingSystem.DTOs;
using BookingSystem.Models;
using BookingSystem.Services;
using BookingSystem.Models.PlaceManagement;
using BookingSystem.Models.Users;

namespace BookingSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<BaseUser> userManager;
        private readonly JWTService jwtService;
        private readonly ValidationService validationService;

        public AuthController(UserManager<BaseUser> userManager, JWTService jwtService, ValidationService validationService)
        {
            this.userManager = userManager;
            this.jwtService = jwtService;
            this.validationService = validationService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterationDTO user)
        {
            if(validationService.em)

            var result = await userManager.CreateAsync(user, dto.Password);
            if (!result.Succeeded)
                return BadRequest(result.Errors);

            await userManager.AddToRoleAsync(user, "Customer"); // or Admin if needed

            var token = await jwtService.GetJWT(user);
            return Ok(new { token });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDTO dto)
        {
            var user = await userManager.FindByEmailAsync(dto.Email);
            if (user == null || !await userManager.CheckPasswordAsync(user, dto.Password))
                return Unauthorized("Invalid credentials");

            var token = await jwtService.GetJWT(user);
            return Ok(new { token });
        }
    }
}
