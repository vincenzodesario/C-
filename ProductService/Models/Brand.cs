
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
namespace ProductService.Models
{
    public class Brand
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public List<Product> Products { get; set; }
    }
}