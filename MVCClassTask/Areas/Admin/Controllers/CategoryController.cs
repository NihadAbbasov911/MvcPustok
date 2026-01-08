using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MVCClassTask.Areas.Admin.ViewModels.Category;
using MVCClassTask.DAL;
using MVCClassTask.Models;
using MVCClassTask.Utilities.Enum;
using MVCClassTask.Utilities.Extensions;

namespace MVCClassTask.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class CategoryController:Controller
    {
        public readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        public CategoryController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }


        public IActionResult Index()
        {
            List<Category> categories = _context.Categories.ToList();
            return View(categories);
        }
        public IActionResult Detail(int? id)
        {
            var category = _context.Categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }
            ;
            return View(category);
        }
        public async Task<ActionResult> Create(CreateCategoryVM createCategoryVM)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            if (!createCategoryVM.Photo.ValidateType("image/"))
            {
                ModelState.AddModelError("Photo", "Please select image file");
                return View();
            }

            if (createCategoryVM.Photo.ValidateSize(FileSize.MB, 10))
            {
                ModelState.AddModelError("Photo", "Image size must be less than 10MB");
                return View();
            }

            bool result = await _context.Categories.AnyAsync(c => c.Name == createCategoryVM.Name);
            if (result)
            {
                ModelState.AddModelError("Name", "This category already exists");
                return View();
            }

            Category category = new Category()
            {
                Name = createCategoryVM.Name,
                Image = await createCategoryVM.Photo.CreateFile(_env.WebRootPath, "assets", "image", "bg-images")
            };

            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }


        
        
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null || id < 1)
            {
                return BadRequest();
            }
            Category category = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);
            if (category is null)
            {
                return NotFound();
            }

            EditCategoryVM editCategoryVM = new EditCategoryVM()
            {
                Name = category.Name,
                Image = category.Image
            };
            return View(editCategoryVM);
        }
        [HttpPost]

        public async Task<ActionResult> Edit(int? id, EditCategoryVM editCategoryVM)
        {
            if (!ModelState.IsValid)
            {
                return View(editCategoryVM);
            }
            Category category = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);

            if (editCategoryVM.Photo is not null)
            {
                if (!editCategoryVM.Photo.ValidateType("image/"))
                {
                    ModelState.AddModelError(nameof(EditCategoryVM.Photo), "The input must be an image");
                    return View(editCategoryVM);
                }
                if (editCategoryVM.Photo.ValidateSize(FileSize.MB, 20))
                {
                    ModelState.AddModelError(nameof(EditCategoryVM.Photo), "The input must be of 20MB size");
                    return View(editCategoryVM);
                }
                string filename = await editCategoryVM.Photo.CreateFile(_env.WebRootPath, "assets", "image", "bg-images");
                category.Image.DeleteFile(_env.WebRootPath, "assets", "image", "bg-images");
                category.Image = filename;
            }

            category.Name = editCategoryVM.Name;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int id)
        {
            Category category = _context.Categories.Find(id);
            if (category  == null) return NotFound();
            category.Image.DeleteFile(_env.WebRootPath, "assets", "image", "bg-images");
            _context.Categories.Remove(category);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
