using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ArtHut.Data.Models
{
    public class Message
    {
        public Message(string subject, string text, string senderId, string receiverId)
		{
            Subject = subject;
            Text = text;
            SenderId = senderId;
            ReceiverId = receiverId;
            SeenAt = DateTime.Now;
		}
        public Message(string subject, string text, User sender, string receiverId)
        {
            Subject = subject;
            Text = text;
            Sender = sender;
            ReceiverId = receiverId;
            SeenAt = DateTime.Now;
        }
        public Message(string subject, string text, string senderId, User receiver)
        {
            Subject = subject;
            Text = text;
            SenderId = senderId;
            Receiver = receiver;
            SeenAt = DateTime.Now;
        }
        public Message(string subject, string text, User sender, User receiver)
        {
            Subject = subject;
            Text = text;
            Sender = sender; ;
            Receiver = receiver;
            SeenAt = DateTime.Now;
        }
        public int Id { get; set; }
        public string Subject { get; set; }
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
