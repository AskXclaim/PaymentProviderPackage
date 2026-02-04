using Application.Enums;

namespace Application.Models
{
    public class Address
    {
        public string AddressLineOne { get; }
        public string AddressLineTwo { get; }
        public string City { get; }
        public string County { get; }
        public AllowedCountry Country { get; }
        public string PostalCode { get; }

        public Address(
            string addressLineOne,
            string addressLineTwo,
            string city,
            string county,
            AllowedCountry country,
            string postalCode)
        {
            AddressLineOne = addressLineOne;
            AddressLineTwo = addressLineTwo;
            City = city;
            County = county;
            Country = country;
            PostalCode = postalCode;
        }
    }
}