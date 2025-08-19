using Microsoft.AspNetCore.Mvc;

namespace Food_Ordering_API.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
