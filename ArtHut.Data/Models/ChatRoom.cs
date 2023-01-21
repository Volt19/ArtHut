using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ArtHut.Data.Models
{
    public class ChatRoom
    {
        public int Id { get; set; }
        public string? User1Id { get; set; }
        [Required]
        [ForeignKey("User1Id")]
        public User User1 { get; set; }
        public string? User2Id { get;set; }
        [Required]
        [ForeignKey("User2Id")]
        public User User2 { get; set; }
        public int? ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }
    }
}
