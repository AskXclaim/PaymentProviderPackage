using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PaymentWeb.Models.Cards;

public class CardRegistrationAddress
{
    [DisplayName("Address line 1")]
    public string? AddressLineOne { get; set; }
    [DisplayName("Address line 2")]
    public string? AddressLineTwo { get; set; }
    [DisplayName("City")]
    public string? City { get; set; }
    [DisplayName("County")]
    public string? County { get; set; }
    [Required][MaxLength(10)]
    [DisplayName("Postal code")]
    public string Postcode { get; set; } = null!;

    [DisplayName("Country")]
    public string? Country { get; set; }

}