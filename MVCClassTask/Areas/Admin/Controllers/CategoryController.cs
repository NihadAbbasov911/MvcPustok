using Microsoft.AspNetCore.Mvc;

namespace MVCClassTask.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class CategoryController:Controller
    {

        public IActionResult Index()
        {
            return View();
        }
    }
}
