using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ArtHut.Data.Models
{
    public class Discount
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "decimal(6, 2)")]
        public decimal DiscountPercent { get; set; }
        [Required]
        public double? Price { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? Starts { get; set; }
        public DateTime? Ends { get; set; }
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }
    }
}
