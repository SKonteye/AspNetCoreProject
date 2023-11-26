using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Chapter18._1.Pages
{
    public class CheckoutModel : PageModel
    {
        [BindProperty]
        public UserBindingModel Input { get; set; }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            return RedirectToPage("Index");
        }
    }
}
