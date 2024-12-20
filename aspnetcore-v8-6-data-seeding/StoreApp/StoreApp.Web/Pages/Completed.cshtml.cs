using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace StoreApp.Web.Pages
{
    public class CompletedModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string? OrderId { get; set; }
        public void OnGet()
        {
        }


    }
}
