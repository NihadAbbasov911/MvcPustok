using MVCClassTask.Areas.Admin.ViewModels.Product;

namespace MVCClassTask.Areas.Admin.ViewModels.Category
{
    public class CategoryWithProductVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public List<Models.Product> Products { get; set; } = new();
    }
}
