using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PaymentWeb.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    [BindProperty(SupportsGet = true)]
    public string Message { get; set; }
    
    public IndexModel(ILogger<IndexModel> logger)=> _logger = logger;
    
    public void OnGet()
    {
        if (!string.IsNullOrWhiteSpace(Message)) return;
        _logger.Log(LogLevel.Information,$"No {nameof(Message)} specified!");
        Message="Anonymous person";
    }
}