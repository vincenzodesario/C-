using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProductService.Models
{
    public class Supplier
    {
        [Key]
        public string Key { get; set; }
        public string Name { get; set; }

        public string Name1 { get; set; }

        public List<Product> Products { get; set; }
    }
}