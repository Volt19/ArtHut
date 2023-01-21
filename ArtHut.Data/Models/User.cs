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
            //UserGroups = new List<UserGroup>();
            //TrackingItemValueActivities =new List<TrackingItemValueActivity>();
            IsDeleted = false;
        }

        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Alias { get; set; }
        public DateTime CreatedAt { get; set; } 
        public bool IsDeleted { get; set; } 
        public ICollection<Product> Products { get; set; }
        public ICollection<Photo> Photos { get; set; }
        public ICollection<ChatRoom> ChatRooms { get; set; }
        public ICollection<ChatRoom> ChatRooms2 { get; set; }
        public ICollection<Massage> Massages { get; set; }
    }
}



