using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ArtHut.Data.Models
{
    public class ProductsTag
    {
        [Key]
        public int Id { get; set; }
        public int? ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }
        public int? TagId { get; set; }
        [ForeignKey("TagId")]
        public Tag Tag{ get; set; }
    }
}
