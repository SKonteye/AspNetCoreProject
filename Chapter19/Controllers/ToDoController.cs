using Microsoft.AspNetCore.Mvc;

namespace Chapter19.Controllers
{
    public class ToDoController : Controller
    {
        private readonly ToDoService _service;
        public ActionResult Category(string id)
        {
            var items = _service.GetItemsForCategory(id);
            return View(items);
        }
        //public ActionResult Create(ToDoListModel model)
        //{
        //    return View(model);
        //}
    }
}
