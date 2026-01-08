using MVCClassTask.Models.Base;

namespace MVCClassTask.Models
{
    public class Product:BaseEntity
    {
     
        public string Name { get; set; }
        public string Author { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
        public decimal OldPrice { get; set; }
        public decimal Discount { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }
}
