using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtHut.Data.Models
{
    public class Order
    {
        public Order() 
        {
            Products = new List<Product>();
        }
        public Order(int addressId, int? paymentId, decimal? shipping, decimal total,
            bool? confirmed, string userId, string receiverFirstName, string receiverLastName, string receiverPhoneNumber, string receiverEmail) :this() 
        {
            AddressId = addressId;
            PaymentId = paymentId;
            Shipping = shipping;
            Total = total;
            Confirmed = confirmed;
            UserId = userId;
            ReceiverFirstName = receiverFirstName;
            ReceiverLastName = receiverLastName;
            ReceiverPhoneNumber = receiverPhoneNumber;
            ReceiverEmail = receiverEmail;
        }

        public int Id { get; set; }
        //public int CartId { get; set; }
        public int AddressId { get; set; }
        [ForeignKey("AddressId")]
        public Address Address { get; set; }
        public int? PaymentId { get; set; }
		[ForeignKey("PaymentId")]
		public Payment? Payment { get; set; }
		[Column(TypeName = "decimal(6, 2)")]
        public decimal? Shipping { get; set; }
        [Column(TypeName = "decimal(6, 2)")]
        public decimal Total { get; set; }
        public bool? Confirmed { get; set; }
        public DateTime CreatedAt { get; set; }
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
        public string ReceiverFirstName { get; set; }
        public string ReceiverLastName { get; set; }
        public string ReceiverPhoneNumber { get; set; }
        public string ReceiverEmail { get; set; }
        public ICollection<Product> Products { get; set; }



    }
}
