using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ArtHut.Data.Models
{
    public class Photo
    {
        public Photo(byte[] bytes, string fileExtension, int? productId, string userId)
        {
            Bytes = bytes;
            FileExtension = fileExtension;
            ProductId = productId;
            UserId = userId;
        }

        [Key]
        public int Id { get; set; }
        public byte[] Bytes { get; set; }
        public string FileExtension { get; set; }
        public string? UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
        public int? ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }
    }
}
