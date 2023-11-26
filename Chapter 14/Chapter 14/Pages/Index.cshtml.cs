using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Chapter_14.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly LinkGenerator _linkGenerator;
        public IndexModel(ILogger<IndexModel> logger, LinkGenerator linkGenerator)
        {
            _logger = logger;
            _linkGenerator = linkGenerator;
        }

        public void OnGet()
        {
            //var url = Url.Page("Currency/View", new { code = "USD" });

            var url1 = Url.Page("Currency/View", new { id = 5 });
            var url3 = _linkGenerator.GetPathByPage(
                                      HttpContext,
                                      "/Currency/View",
                                      values: new { id = 5 });
            var url2 = _linkGenerator.GetPathByPage(
                                     "/Currency/View",
                                     values: new { id = 5 });
            var url4 = _linkGenerator.GetUriByPage(
                page: "/Currency/View",
                handler: null,
                values: new { id = 5 },
                scheme: "https",
                host: new HostString("example.com"));

        }
    }
}