using MVCClassTask.Models.Base;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCClassTask.Models
{
    public class Category:BaseEntity
    {
        [MaxLength(30, ErrorMessage = "Name 30 dan cox yazmaq olmaz")]
        public string Name { get; set; }
        public string Image { get; set; }
        public List<Product>? Products { get; set; }



    }
}
