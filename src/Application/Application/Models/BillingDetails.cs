
namespace Application.Models
{
    public class BillingDetails
    {
        public Address Address { get; set; } 
        public string Phone { get; set; }
        public BillingDetails(Address address, string phone)
        {
            Address = address;
            Phone = phone;
        }

    }
}