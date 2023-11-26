using Microsoft.AspNetCore.Mvc;

namespace Chapter20._9.Controllers
{
    public class AppointmentController : Controller
    {
        [HttpGet("/appointments")]
        public IActionResult ListAppointments()
        {
            /* method implementation*/
            return View();
        }

        [HttpPost("/appointments")]
        public IActionResult CreateAppointment()
        {
            /* method implementation*/
            return View();

        }
    }
}
