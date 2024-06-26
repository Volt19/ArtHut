﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ArtHut.Data.Models
{
    public class CartItem
    {
        public CartItem()
        {
        }
        public CartItem( int prodctId, string userId, bool IsActive) : this()
		{
            ProductId = prodctId;
            UserId = userId;
            IsSold = IsActive;
        }
        public int Id { get; set; }
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
        public bool? IsSold { get; set; }
    }
}
