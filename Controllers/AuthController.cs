using Food_Ordering_API.Data;
using Food_Ordering_API.Models;
using Food_Ordering_API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Food_Ordering_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly AuthService _authService;

        public AuthController(ApplicationDbContext context, AuthService authService)
        {
            _context = context;
            _authService = authService;
        }

        [HttpPost("register")]
        public IActionResult Register(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return Ok("User registered");
        }

        [HttpPost("login")]
        public IActionResult Login(User login)
        {
            var user = _context.Users.SingleOrDefault(u => u.Username == login.Username && u.Password == login.Password);
            if (user == null) return Unauthorized();

            var token = _authService.GenerateJwtToken(user);
            return Ok(new { Token = token, Role = user.Role });
        }

        [HttpGet("users")]
        public IActionResult GetAllUsers()
        {
            var users = _context.Users
                .Select(u => new { u.Id, u.Username, u.Role })
                .ToList();

            return Ok(users);
        }
    }
}
