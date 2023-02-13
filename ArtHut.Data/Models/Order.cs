using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtHut.Data.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int CartId { get; set; }
        public int Address { get; set; }
        public int Payment { get; set; }
        public double Total { get; set; }
        public bool Confirmed { get; set; }
        public DateTime CreatedAt { get; set; }


    }
}
