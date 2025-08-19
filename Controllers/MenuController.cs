using Food_Ordering_API.Data;
using Food_Ordering_API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Food_Ordering_API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class MenuController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public MenuController(ApplicationDbContext context) => _context = context;

        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetMenu() => Ok(_context.Menu.ToList());

        [HttpPost]
        [Authorize(Roles = "Admin,admin")]
        public IActionResult AddMenuItem(MenuItem item)
        {
            _context.Menu.Add(item);
            _context.SaveChanges();
            return Ok("Item added");
        }
    }
}
