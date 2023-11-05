using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Chapter17._6.Pages
{
    public class ToDoItemModel : PageModel
    {
        public bool IsComplete { get; set; }
        public List<string> Tasks { get; set; } = new List<string>
        {
            "Get Fuel",
            "<strong>Check oil</strong>",
            "Check Tyre pressure"
        };
        public void OnGet()
        {
        }
    }
}
