using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Chapter16._5_binding_source.Pages
{
    public class PhotosModel : PageModel
    {
        public void OnPost(
            [FromHeader] string userId,
            [FromBody] List<Photo> photos)
        {
        }
    }

    public class Photo
    {
    }
}
