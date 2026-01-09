namespace MVCClassTask.Areas.Admin.ViewModels.Product
{
    public class ProductDetailVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string ImageUrl { get; set; }

        public decimal Price { get; set; }
        public decimal OldPrice { get; set; }
        public decimal Discount { get; set; }

        public string CategoryName { get; set; }
    }

}
