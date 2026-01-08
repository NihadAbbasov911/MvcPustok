using Microsoft.AspNetCore.Mvc;
using MVCClassTask.DAL;

namespace MVCClassTask.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        public readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        public ProductController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public async Task <IActionResult> Index()
        {
            //var product =
            //await _context.Products
            //.Include(p => p.Category)
            //.ToListAsync();
            return View();
        }
    }
}
