
namespace MVCClassTask.Areas.Admin.ViewModels.Product

{
    public class CreateProductVM
    {
        public string Name { get; set; }
        public string Author { get; set; }

        public IFormFile Image { get; set; }

        public decimal Price { get; set; }
        public decimal OldPrice { get; set; }
        public decimal Discount { get; set; }

        public int CategoryId { get; set; }
        public List<Models.Category>? Categories { get; set; }
    }
}
