using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Chapter18._5_18._6.Pages
{
    public class SelectListsModel : PageModel
    {
        [BindProperty]
        public InputModel Input { get; set; }
        public IEnumerable<SelectListItem> Items { get; set; }
            = new List<SelectListItem>
        {
            new SelectListItem{Value = "csharp", Text="C#"},
            new SelectListItem{Value = "python", Text="Python"},
            new SelectListItem{Value = "cpp", Text="C++"},
            new SelectListItem{Value = "java", Text="Java"},
            new SelectListItem{Value = "js", Text="JavaScript"},
            new SelectListItem{Value = "ruby", Text="Ruby"},
        };

        public class InputModel
        {
            public string SelectedValue1 { get; set; }
            public string SelectedValue2 { get; set; }
            public IEnumerable<string> MultiValues { get; set; }
        }

    }
}

