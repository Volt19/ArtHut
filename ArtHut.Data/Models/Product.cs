using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ArtHut.Data.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } 
        public string? Description { get; set; }
        public bool IsUnique { get; set; }
        public int? Qantity { get; set; }
        [Required]
        public double? Price { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public bool? IsSold { get; set; }
        public ICollection<Photo> Photos { get; set; }
        public ICollection<ChatRoom> ChatRooms { get; set; }
    }
}
