using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ArtHut.Data.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string? Description { get; set; }
        public int? ParentCategory { get; set; }
        [ForeignKey("ParentCategory")]
        public Category? PCategory { get; set; }
        public ICollection<Category> Categories { get; set; }
        public ICollection<ProductsCategory> ProductsCategories { get; set; }

    }
}
