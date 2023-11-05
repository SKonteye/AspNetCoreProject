using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Chapter17._2.Pages
{
    public class TaskModel : PageModel
    {
        public List<string> Tasks { get; set; }
        public string Title { get; set; }
        public void OnGet(int id)
        {
            Title = "Tasks for today";
            Tasks = new List<string>
            {
                "Get fuel",
                "Check oil",
                "Check tyre pressure"
            };
        }
    }
}
