using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PaymentWeb.Models;

public class CardRegistration
{
    [Required] [Display(Name = "First Name") ] public string FirstName { get; set; }
    [Required] [DisplayName("Last Name")] public string LastName { get; set; }

    [Required]
    [EmailAddress]
    [DisplayName("Email")]
    public string Email { get; set; }

    [Required]
    [Phone]
    [DisplayName("Phone")]
    public string PhoneNumber { get; set; }
    public CardRegistrationAddress Address { get; set; }
}