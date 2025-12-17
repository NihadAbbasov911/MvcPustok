using Microsoft.AspNetCore.Mvc;

namespace MVCClassTask.Controllers
{
    public class AuthController:Controller
    {
        public IActionResult Index()
        {
            return View();

        }
    }
}
