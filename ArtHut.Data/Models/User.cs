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
        //public User()
        //{
        //    //Name = string.Empty;
        //    ////UserGroups = new List<UserGroup>();
        //    ////TrackingItemValueActivities =new List<TrackingItemValueActivity>();
        //    //IsDeleted = false;
        //}

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Alias { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsDeleted { get; set; } = false;
        public ICollection<Product> Products { get; set; }
        public ICollection<Photo> Photos { get; set; }
    }
}



