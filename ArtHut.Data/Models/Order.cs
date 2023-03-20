using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtHut.Data.Models
{
    public class Order
    {
        public int Id { get; set; }
        //public int CartId { get; set; }
        public int AddressId { get; set; }
        [ForeignKey("AddressId")]
        public Address Address { get; set; }
        public int? Payment { get; set; }
        [Column(TypeName = "decimal(6, 2)")]
        public decimal? Shipping { get; set; }
        [Column(TypeName = "decimal(6, 2)")]
        public decimal Total { get; set; }
        public bool Confirmed { get; set; }
        public DateTime CreatedAt { get; set; }
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }


    }
}
