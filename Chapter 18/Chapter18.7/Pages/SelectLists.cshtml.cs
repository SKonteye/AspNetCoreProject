using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Chapter18._7.Pages
{
    public class SelectListsModel : PageModel
    {
        [BindProperty]
        public IEnumerable<string> SelectedValues { get; set; }
        public IEnumerable<SelectedListItem> Items { get; set; }

        public SelectListsModel() {
            var dynamic = new SelectListGroup { Name = "Dynamic" };
            var @static = new SelectListGroup { Name = "Static" };
            Items = new List<SelectedListItem>
            {
                new SelectedListItem
                {
                    Value = "js",
                    Text = "JavaScript",
                    Group = dynamic
                },
                new SelectedListItem
                {
                    Value = "cpp",
                    Text = "C++",
                    Group = @static
                },
                new SelectedListItem
                {
                    Value = "python",
                    Text = "Python",
                    Group = dynamic
                },
                new SelectedListItem
                {
                    Value = "csharp",
                    Text = "C#",
                }
            };
        }
        public void OnGet()
        {
        }
    }

    public class SelectedListItem
    {
        public string Value { get; set; }
        public string Text { get; set; }
        public SelectListGroup? Group { get; set; }
    }
}
