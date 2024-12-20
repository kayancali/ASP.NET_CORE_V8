using Microsoft.AspNetCore.DataProtection.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StoreApp.Data.Abstract;
using StoreApp.Web.Helpers;
using StoreApp.Web.Models;

namespace StoreApp.Web.Pages
{
    public class CartModel : PageModel
    {
        private IStoreRepository _repository;
        public CartModel(IStoreRepository repository, Cart cartService)
        {
            _repository = repository;
            Cart = cartService;
        }

        public Cart? Cart { get; set; }
        public void OnGet()
        {
        }

        public IActionResult OnPost(int id)
        {
            var product = _repository.Products.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                
                Cart?.AddItem(product,1);
                
            }
            return RedirectToPage("/Cart");
        }

        public IActionResult OnPostDelete(int id)
        {
            var product = _repository.Products.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                Cart?.RemoveItem(product);
            }
            return RedirectToPage("/Cart");
        }
    }
}
