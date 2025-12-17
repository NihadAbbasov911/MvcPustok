using Microsoft.AspNetCore.Mvc;

namespace MVCClassTask.Controllers
{
    public class ProductController:Controller
    {
        public IActionResult Index()
        {
            return View();

        }
    }
}
