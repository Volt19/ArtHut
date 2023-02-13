using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ArtHut.Data.Models
{
    public class Address
    {
        public int Id { get; set; }
        public int CountryId { get; set; }
        [ForeignKey("CountryId")]
        public Country Country { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string StreetAddress { get; set; }
        public string Comment { get; set; }
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
