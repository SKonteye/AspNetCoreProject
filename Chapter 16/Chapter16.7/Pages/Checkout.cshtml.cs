using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Chapter16._7.Pages
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

            /* Save to the database, update user, return success */

            return RedirectToPage("Success");
        }
    }
}
