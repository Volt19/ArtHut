using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using static Duende.IdentityServer.Models.IdentityResources;

namespace ArtHut.Data.Models
{
    public class Address
    {
        public Address()
        {
        }
        public Address(int countryId, string district, string city, string postalCode, string streetAddress)
            //,string addresseeFirstName, string addresseeLastName, string addresseePhoneNumber, string addresseeEmail)
        {
            CountryId = countryId;
            District = district;
            City = city;
            PostalCode = postalCode;
            StreetAddress = streetAddress;
			//АddresseeFirstName = addresseeFirstName;
			//АddresseeLastName= addresseeLastName;
			//АddresseePhoneNumber= addresseePhoneNumber;
			//АddresseeEmail = addresseeEmail;
		}
        public int Id { get; set; }
        public int CountryId { get; set; }
        [ForeignKey("CountryId")]
        public Country Country { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string StreetAddress { get; set; }
	//	public string АddresseeFirstName { get; set; }
	//	public string АddresseeLastName { get; set; }
	//	public string АddresseePhoneNumber { get; set; }
	//	public string АddresseeEmail { get; set; }
	}
}
