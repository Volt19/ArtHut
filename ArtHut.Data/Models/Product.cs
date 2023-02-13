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
        public Product()
        {
            Photos = new List<Photo>();
            ProductsTags = new List<ProductsTag>();
            ProductsLikes = new List<ProductsLikes>();
            ProductsCategories = new List<ProductsCategory>();
        }
        public Product(string name, string? description, double price, string? size, bool isUnique, int? qantity, User user) : this()
        {
            Name = name;
            Description=description;
            Price=price;
            Size= size;
            IsUnique=isUnique;
            Qantity=qantity;
            User=user;
        }
        public Product(string name, string? description, double price, string? size, bool isUnique, int? qantity, string userId) : this()
        {
            Name = name;
            Description=description;
            Price=price;
            Size= size;
            IsUnique=isUnique;
            Qantity=qantity;
            UserId=userId;
        }

        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public bool? IsUnique { get; set; }
        public int? Qantity { get; set; }
        //[Column(TypeName = "decimal(6, 2)")]
        public double? Price { get; set; }
        public string? Size { get; set; }
        public DateTime? CreatedAt { get; set; }
        //public DateTime? ModifiedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public bool? IsSold { get; set; }
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
        public ICollection<Photo> Photos { get; set; }
        public ICollection<ProductsTag> ProductsTags { get; set; }
        public ICollection<ProductsLikes> ProductsLikes { get; set; }
        public ICollection<ProductsCategory> ProductsCategories { get; set; }
    }
}
