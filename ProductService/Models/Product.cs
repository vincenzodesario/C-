
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
namespace ProductService.Models
{
    public class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public decimal Price3 { get; set; }

        public string Category { get; set; }
        public decimal Price2 { get; set; }
        public string Name2 { get; set; }

        public string Name3 { get; set; }

        public string Name4 { get; set; }
        public string Category2 { get; set; }

        [ForeignKey("Supplier")]
        public string SupplierId { get; set; }
        public virtual Supplier Supplier { get; set; }

        // Navigation
        public virtual ICollection<ProductRating> Ratings { get; set; }
    }
}