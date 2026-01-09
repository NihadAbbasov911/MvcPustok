using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCClassTask.Areas.Admin.ViewModels.Product;
using MVCClassTask.DAL;
using MVCClassTask.Models;
using MVCClassTask.Utilities.Enum;
using MVCClassTask.Utilities.Extensions;

namespace MVCClassTask.Areas.Admin.Controllers
{
    [Area ("Admin")]
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
            List<GetProductVM> productVMs =
            await _context.Product
            .Include(p => p.Category)
            .Select(p => new GetProductVM {
                Id = p.Id,
                Name= p.Name,
                Author= p.Author,
                Image= p.ImageUrl,
                Price= p.Price,
              
                CategoryName=p.Category.Name

            })
            .ToListAsync();
            return View(productVMs);
        }
        public IActionResult Detail(int id)
        {
            var product = _context.Product
                .Include(p => p.Category)
                .FirstOrDefault(p => p.Id == id);

            if (product == null) return NotFound();

            ProductDetailVM vm = new ProductDetailVM
            {
                Id = product.Id,
                Name = product.Name,
                Author = product.Author,
                ImageUrl = product.ImageUrl,
                Price = product.Price,
                OldPrice = product.OldPrice,
                Discount = product.Discount,
                CategoryName = product.Category.Name
            };

            return View(vm);
        }
        public IActionResult Create()
        {
            CreateProductVM vm = new CreateProductVM
            {
                Categories = _context.Categories.ToList()
            };

            return View(vm);
        }
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateProductVM vm)
        {
            if (!ModelState.IsValid)
            {
                vm.Categories = _context.Categories.ToList();
                return View(vm);
            }

            if (vm.Image == null)
            {
                ModelState.AddModelError("Image", "Please select an image.");
                vm.Categories = _context.Categories.ToList();
                return View(vm);
            }

            if (!vm.Image.ValidateType("image"))
            {
                ModelState.AddModelError("Image", "File type must be an image.");
                vm.Categories = _context.Categories.ToList();
                return View(vm);
            }

            if (vm.Image.ValidateSize(FileSize.MB, 2))
            {
                ModelState.AddModelError("Image", "File size must be less than 2 MB.");
                vm.Categories = _context.Categories.ToList();
                return View(vm);
            }


            string fileName = await vm.Image.CreateFile("wwwroot", "assets", "image", "products");


            Product product = new Product
            {
                Name = vm.Name,
                Author = vm.Author,
                Price = vm.Price,
                OldPrice = vm.OldPrice,
                Discount = vm.Discount,
                CategoryID = vm.CategoryId,
                ImageUrl = fileName
            };

            _context.Product.Add(product);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            
            var product = await _context.Product.FindAsync(id);
            if (product == null) return NotFound();

            
            if (!string.IsNullOrEmpty(product.ImageUrl))
            {
                string folderPath = Path.Combine(_env.WebRootPath, "assets", "image", "products");
                product.ImageUrl.DeleteFile(folderPath);
            }

           
            _context.Product.Remove(product);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Update(int id)
        {
            var product = await _context.Product.FindAsync(id);
            if (product == null) return NotFound();

            UpdateProductVM vm = new UpdateProductVM
            {
                Name = product.Name,
                Author = product.Author,
                Price = product.Price,
                OldPrice = product.OldPrice,
                Discount = product.Discount,
                CategoryId = product.CategoryID,
                Categories = _context.Categories.ToList()
            };

            ViewData["CurrentImage"] = product.ImageUrl;
            ViewData["id"] = product.Id;  // route üçün

            return View(vm);
        }

        // POST: Update
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, UpdateProductVM vm)
        {
            var product = await _context.Product.FindAsync(id);
            if (product == null) return NotFound();

            if (!ModelState.IsValid)
            {
                vm.Categories = _context.Categories.ToList();
                return View(vm);
            }

            // Image dəyişdirsə
            if (vm.Image != null)
            {
                string folder = Path.Combine(_env.WebRootPath, "assets", "images", "products");
                Directory.CreateDirectory(folder);

                if (!string.IsNullOrEmpty(product.ImageUrl))
                {
                    product.ImageUrl.DeleteFile(folder);
                }

                product.ImageUrl = await vm.Image.CreateFile(folder);
            }

            product.Name = vm.Name;
            product.Author = vm.Author;
            product.Price = vm.Price;
            product.OldPrice = vm.OldPrice;
            product.Discount = vm.Discount;
            product.CategoryID = vm.CategoryId;

            _context.Product.Update(product);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }






    }
}
