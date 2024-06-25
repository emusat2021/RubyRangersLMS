using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RubyRangersLMS_API.Models;
using System.Threading.Tasks;

namespace RubyRangersLMS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        // Dependency injection from AddIdentity<> in Program.cs
        public AuthController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);

            if (user == null)
            {
                return Unauthorized("Invalid Email or Password");
            }

            // Beware the last false variable sets lockout to false.
            // May make us vulnerable to brute force attacks.
            var result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);

            if (!result.Succeeded)
            {
                return Unauthorized("Invalid Email or Password");
            }

            // Should return some form of token but for now i just return Ok. Baby steps.
            return (Ok("Credentials Accepted!"));
        }
    }
}
