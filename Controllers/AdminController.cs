using FoodOrdering__API.Models;
using FoodOrdering__API.Services;
using Microsoft.AspNetCore.Mvc;

namespace FoodOrdering__API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdminController : ControllerBase
    {
        private readonly IMenuService _menuService;

        public AdminController(IMenuService menuService)
        {
            _menuService = menuService;
        }

        [HttpGet("menu")]
        public ActionResult<List<FoodItem>> GetMenu() => _menuService.GetMenu();

        [HttpPost("menu")]
        public ActionResult<FoodItem> AddMenu([FromBody] FoodItem item)
        {
            var created = _menuService.AddMenu(item);
            return CreatedAtAction(nameof(GetMenu), new { id = created.Id }, created);
        }

        [HttpPut("menu/{id:int}")]
        public IActionResult UpdateMenu([FromRoute] int id, [FromBody] FoodItem item)
        {
            var ok = _menuService.UpdateMenu(id, item);
            if (!ok) return NotFound();
            return NoContent();
        }

        [HttpDelete("menu/{id:int}")]
        public IActionResult DeleteMenu([FromRoute] int id)
        {
            var ok = _menuService.DeleteMenu(id);
            if (!ok) return NotFound();
            return NoContent();
        }
    }
}
