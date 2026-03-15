using Microsoft.AspNetCore.Mvc;
using NSS_API.Data;
using NSS_API.Models;
using NSS_API.Services;
using Microsoft.EntityFrameworkCore;

namespace NSS_API.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly EmailService _emailService;

        public AuthController(AppDbContext context, EmailService emailService)
        {
            _context = context;
            _emailService = emailService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto data)
        {
            if (await _context.Users.AnyAsync(u => u.Email == data.Email))
                return BadRequest("Email already registered!");

            string role = "Volunteer";
            int? classId = null;

            if (!string.IsNullOrEmpty(data.LeaderID))
            {
                var cls = await _context.Classes.FirstOrDefaultAsync(c => c.SecretLeaderID == data.LeaderID);
                if (cls != null) { role = "Leader"; classId = cls.ClassID; }
                else return BadRequest("Invalid Leader ID!");
            }

            string otp = new Random().Next(100000, 999999).ToString();

            var user = new User
            {
                FullName = data.FullName,
                Email = data.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(data.Password),
                Role = role,
                ClassID = classId,
                OTPCode = otp,
                IsVerified = false,
                // Baaki fields mapping yahan kar dena...
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            await _emailService.SendOtpAsync(user.Email, otp);

            return Ok("User registered. Please verify OTP sent to email.");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto data)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == data.Email);
            if (user == null || !BCrypt.Net.BCrypt.Verify(data.Password, user.PasswordHash))
                return Unauthorized("Invalid credentials!");

            if (!user.IsVerified) return BadRequest("Please verify your email first.");

            return Ok(new { user.UserID, user.FullName, user.Role, user.Email });
        }
    }
}