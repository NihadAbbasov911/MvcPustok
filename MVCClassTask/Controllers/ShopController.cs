using Microsoft.AspNetCore.Mvc;

namespace MVCClassTask.Controllers
{
    public class ShopController:Controller
    {
        public IActionResult Index()
        {
            return View();

        }
    }
}
