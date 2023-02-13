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
        public string Text { get; set; }
        public string SenderId { get; set; }
        [Required]
        [ForeignKey("SenderId")]
        public User Sender   { get; set; }
        public string ReceiverId { get; set; }
        [Required]
        [ForeignKey("ReceiverId")]
        public User Receiver { get; set; }
        public DateTime SendAt { get; set; }
        public DateTime? SeenAt { get; set; }
    }
}
