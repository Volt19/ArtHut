using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ArtHut.Data.Models
{
    public class Massage
    {
        public int Id { get; set; }
        public DateTime SendAt { get; set; }
        public DateTime? seenAt { get; set; }
        public string Text { get; set; }
        public int ChatRoomId { get; set; }
        [ForeignKey("ChatRoomId")]
        public ChatRoom ChatRoom { get; set; }
        public string UserId { get; set; }
        [Required]
        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
