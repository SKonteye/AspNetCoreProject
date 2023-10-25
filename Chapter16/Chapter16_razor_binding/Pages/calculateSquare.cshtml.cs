using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Chapter16_razor_binding.Pages
{
    public class CalculateSquareModel : PageModel
    {
        public int Input {  get; set; }
        public int Square { get; set; }
        public void OnGet(int number)
        {
            Square = number*number;
            Input = number;
        }
    }
}
