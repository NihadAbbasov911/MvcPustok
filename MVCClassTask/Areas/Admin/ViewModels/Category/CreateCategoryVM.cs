using System.ComponentModel.DataAnnotations.Schema;

namespace MVCClassTask.Areas.Admin.ViewModels.Category
{
    public class CreateCategoryVM
    {
        public string Name { get; set; }
       
        
        public IFormFile Photo { get; set; }
    }
}
