using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace Chapter18._1.Pages
{
    public class ConvertModel : PageModel
    {
        [BindProperty]
        [Required]
        [StringLength(100)]
        public string CurrencyFrom { get; set; }
        [BindProperty]
        [Required]
        public string CurrencyTo { get; set; }
        [BindProperty]
        [Required]
        public int Quantity { get; set; }
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
