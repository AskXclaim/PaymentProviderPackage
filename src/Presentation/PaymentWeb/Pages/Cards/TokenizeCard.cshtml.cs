using Application.Dtos;
using Application.Enums;
using Application.Interfaces;
using Application.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PaymentWeb.Models.Cards;
using PaymentWeb.Shared;

namespace PaymentWeb.Pages.Cards;

public class TokenizeCard : PageModel
{
    private readonly IPaymentGateway _paymentGateway;
    private readonly IConfiguration _config;
    private readonly LinkGenerator _linkGenerator;

    public string? PaymentProviderId { get; set; }

    public TokenizeCard(IPaymentGateway paymentGateway, IConfiguration config, LinkGenerator linkGenerator)
    {
        _paymentGateway = paymentGateway;
        _config = config;
        _linkGenerator = linkGenerator;
    }

    [NonAction]
    public async Task OnGet()
    {
        var cardRegistration = TempData.Get<CardRegistration>("cardRegistration");
        if (cardRegistration != null)
        {
            var request = new GeneratePaymentSessionRequestDto(_config["processingChannelId"],
                new BillingDetails(
                    new Address(cardRegistration.Address.AddressLineOne, cardRegistration.Address.AddressLineTwo,
                        cardRegistration.Address.City, cardRegistration.Address.County, AllowedCountry.GB,
                        cardRegistration.Address.Postcode), cardRegistration.PhoneNumber),
                0, Currency.GBP,
                GetUriByPage("TokenizedSuccessfully"),
                GetUriByPage("TokenizationFailed"), GetReference(cardRegistration), new BillingDescriptor
                {
                    City = cardRegistration.Address.City,
                    Name = $"{cardRegistration.FirstName} {cardRegistration.LastName}",
                    Reference = $"some-reference-{cardRegistration.FirstName}-{cardRegistration.LastName}",
                }, new Customer
                {
                    Email = cardRegistration.Email, FirstName = cardRegistration.FirstName,
                    LastName = cardRegistration.LastName, Id = "1"
                }, "displayName");
            var response = await _paymentGateway.GeneratePaymentSession(request).ConfigureAwait(false);
            if (response != null)
            {
                TempData.Set("paymentSession", response.PaymentSession);
                PaymentProviderId = response.PaymentSession.Id;
            }
        }
    }

    private string? GetUriByPage(string pageName) =>
        _linkGenerator.GetUriByPage(HttpContext, $"/Cards/{pageName}");


    //Remember reference has to be less than or equal to 50 character
    private string GetReference(CardRegistration cardRegistration) =>
        $"Tokenize-{cardRegistration.FirstName}-{cardRegistration.LastName}";
}