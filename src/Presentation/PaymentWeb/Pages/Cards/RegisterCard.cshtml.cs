using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PaymentWeb.Models.Cards;
using PaymentWeb.Shared;

namespace PaymentWeb.Pages.Cards;

[BindProperties]
public class RegisterCardModel : PageModel
{
    public CardRegistration CardRegistration { get; set; } = new()
    {
        Address = new CardRegistrationAddress()
    };

    public void OnGet()
    {
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
            return Page();
        TempData.Set("cardRegistration", CardRegistration);
        return RedirectToPage("/Cards/TokenizeCard");
    }
}