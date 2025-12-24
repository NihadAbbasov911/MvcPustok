using Microsoft.AspNetCore.Mvc;

namespace MVCClassTask.Areas.Admin.Controllers
{
    [Area("Admin")] 
    public class HomeController:Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
