using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace Chapter18._1.Pages
{
    public class ConvertModel : PageModel
    {
        [BindProperty]
        public InputModel Input { get; set; }
        [HttpPost]
        public IActionResult OnPost()
        {
            if (Input.CurrencyFrom == Input.CurrencyTo)
            {
                ModelState.AddModelError(
                    string.Empty,
                    "Cannot convert currency to  itself");
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }
            return RedirectToPage("Checkout");
        }

    }
    public class InputModel
    {
        [Required]
        [StringLength(100)]
        public string CurrencyFrom { get; set; }
        [Required]
        public string CurrencyTo { get; set; }
        [Required]
        public int Quantity { get; set; }
    }
}
