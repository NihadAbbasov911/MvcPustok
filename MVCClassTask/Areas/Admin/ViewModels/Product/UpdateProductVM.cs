using System.ComponentModel.DataAnnotations;

namespace MVCClassTask.Areas.Admin.ViewModels.Product
{
  
        public class UpdateProductVM
        {
            [Required]
            [StringLength(100)]
            public string Name { get; set; }

            [Required]
            [StringLength(100)]
            public string Author { get; set; }

            [Required]
            [Range(0, double.MaxValue)]
            public decimal Price { get; set; }

        [Range(0, double.MaxValue)]
        public decimal OldPrice { get; set; } 

        [Range(0, 100)]
        public decimal Discount { get; set; } 

            [Required(ErrorMessage = "Please select a category")]
            public int CategoryId { get; set; }

            public IFormFile? Image { get; set; }   

            
            public List<Models.Category>? Categories { get; set; }
        }
    }

