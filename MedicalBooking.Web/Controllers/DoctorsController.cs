using Microsoft.AspNetCore.Mvc;

namespace MedicalBooking.Web.Controllers
{
    public class DoctorsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
