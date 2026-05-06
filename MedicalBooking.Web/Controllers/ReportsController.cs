using MedicalBooking.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MedicalBooking.Web.Controllers
{
    [Authorize]
    public class ReportsController : Controller
    {
        private readonly HttpClient _client;

        public ReportsController(IHttpClientFactory factory)
        {
            _client = factory.CreateClient("MedicalAPI");
        }

        public async Task<IActionResult> Index()
        {
            var response = await _client.GetAsync("api/reporting/summary");

            if (!response.IsSuccessStatusCode)
                return View(new AppointmentReport());

            var data = await response.Content.ReadAsStringAsync();

            var report = JsonConvert.DeserializeObject<AppointmentReport>(data)
                         ?? new AppointmentReport();

            return View(report);
        }
    }
}