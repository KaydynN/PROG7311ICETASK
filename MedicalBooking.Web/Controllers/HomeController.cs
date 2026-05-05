using Microsoft.AspNetCore.Mvc;
using MedicalBooking.Web.Models;

namespace MedicalBooking.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() => View();

        public IActionResult Privacy() => View();

        public IActionResult Error() => View(new ErrorViewModel());
    }
}
