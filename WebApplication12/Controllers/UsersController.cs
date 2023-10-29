using Microsoft.AspNetCore.Mvc;

namespace WebApplication12.Controllers
{
    public class UsersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
