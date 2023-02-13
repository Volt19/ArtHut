using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace ArtHut.Data.Models
{
    public class User : IdentityUser
    {
        public User()
        {

            CreatedAt = DateTime.Now;
            IsPublic = false;
            Products = new List<Product>();
            Photos =new List<Photo>();
            Addresses = new List<Address>();
            LikedArtists = new List<LikedArtist>();
            ProductsLikes = new List<ProductsLikes>();
        }

        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Alias { get; set; }
        public bool IsPublic { get; set; }
        public DateTime CreatedAt { get; set; }
        public ICollection<Product> Products { get; set; }
        public ICollection<Photo> Photos { get; set; }
        public ICollection<Massage> Senders { get; set; } 
        public ICollection<Massage> Receivers { get; set; }
        public ICollection<Address> Addresses { get; set; }
        public ICollection<LikedArtist> LikedArtists { get; set; }
        public ICollection<ProductsLikes> ProductsLikes { get; set; }


    }
}



