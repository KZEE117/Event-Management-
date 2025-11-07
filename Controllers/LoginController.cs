using Microsoft.AspNetCore.Mvc;
using EventManagement.Data;
using EventManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace EventManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly EventDbContext _context;

        public LoginController(EventDbContext context)
        {
            _context = context;
        }

        // ✅ Login using only UserName
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest login)
        {
            var user = await _context.Admins
                .FirstOrDefaultAsync(u => u.UserName == login.UserName);

            if (user == null)
                return Unauthorized(new { message = "User not found. Please register first." });

            // ✅ Store session
            HttpContext.Session.SetString("UserName", user.UserName);
            HttpContext.Session.SetInt32("RegistrationId", user.RegistrationId);

            return Ok(new { message = "Login successful", user = user.UserName });
        }

        // ✅ Logout
        [HttpPost("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return Ok(new { message = "Logged out successfully" });
        }
    }

}
