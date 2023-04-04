using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ArtHut.Data.Models
{
	public class Payment
	{
		public Payment() { }
		public Payment(string cardholderName, string cardNumber, string expirationDate, string CVV): this()
		{
			CardholderName= cardholderName;
			CardNumber= cardNumber;
			ExpirationDate= expirationDate;
			this.CVV = CVV;
		}
		public int Id { get; set; }
		public string CardholderName { get; set; }
		public string CardNumber { get; set; }
		public string ExpirationDate { get; set; }
		public string CVV { get; set; }
	}
}
