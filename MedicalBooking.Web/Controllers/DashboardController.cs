using Microsoft.AspNetCore.Mvc;
using MedicalBooking.Web.Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;

namespace MedicalBooking.Web.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        private readonly HttpClient _client;

        public DashboardController(IHttpClientFactory factory)
        {
            _client = factory.CreateClient("MedicalAPI");
        }

        public async Task<IActionResult> Index()
        {
            var response = await _client.GetAsync("api/reporting/summary");

            var report = new AppointmentReport();

            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                report = JsonConvert.DeserializeObject<AppointmentReport>(data) ?? new();
            }

            return View(report);
        }
    }
}