namespace MVCClassTask.Areas.Admin.ViewModels.Category
{
    public class EditCategoryVM
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public IFormFile? Photo { get; set; }
    }
}
