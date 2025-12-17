using Microsoft.AspNetCore.Mvc;

namespace MVCClassTask.Controllers
{
    public class BlogController:Controller
    {
        public IActionResult Index()
        {
            return View();

        }
    }
}
