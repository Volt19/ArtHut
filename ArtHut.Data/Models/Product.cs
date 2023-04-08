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
        public Product(string name, string? description, decimal price, string? size, int? quantity, User user, int categoryId) : this()
        {
            Name = name;
            Description=description;
            Price=price;
            Size= size;
            Quantity=quantity;
            User=user;
            CategoryId=categoryId;
        }
        public Product(string name, string? description, decimal price, string? size, int? quantity, string userId, int categoryId) : this()
        {
            Name = name;
            Description=description;
            Price=price;
            Size= size;
            Quantity=quantity;
            UserId=userId;
            CategoryId=categoryId;
        }

        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int? Quantity { get; set; }
        [Column(TypeName = "decimal(6, 2)")]
        public decimal? Price { get; set; }
        public string? Size { get; set; }
        public DateTime? CreatedAt { get; set; }
        //public DateTime? ModifiedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public int? IsSold { get; set; }
        [ForeignKey("IsSold")]
        public Order Order { get; set; }
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
        public int? CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
        public ICollection<Photo> Photos { get; set; }
        public ICollection<CartItem> CartItems { get; set; }
        public ICollection<ProductsTag> ProductsTags { get; set; }
        public ICollection<ProductsLikes> ProductsLikes { get; set; }
        public ICollection<ProductsCategory> ProductsCategories { get; set; }
    }
}
