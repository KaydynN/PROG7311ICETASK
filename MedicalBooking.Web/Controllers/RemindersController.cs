using MedicalBooking.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MedicalBooking.Web.Controllers
{
    [Authorize]
    public class RemindersController : Controller
    {
        private readonly HttpClient _client;

        public RemindersController(IHttpClientFactory factory)
        {
            _client = factory.CreateClient("MedicalAPI");
        }

        public async Task<IActionResult> Index()
        {
            var response = await _client.GetAsync("api/appointments");

            if (!response.IsSuccessStatusCode)
                return View(new List<Reminder>());

            var data = await response.Content.ReadAsStringAsync();

            var appointments = JsonConvert.DeserializeObject<List<Appointment>>(data)
                               ?? new List<Appointment>();

            var reminders = appointments
                .Where(a =>
                    !a.Attended &&
                    a.AppointmentDate > DateTime.Now &&
                    a.AppointmentDate <= DateTime.Now.AddMinutes(30))
                .Select(a => new Reminder
                {
                    Id = a.Id,
                    PatientName = a.PatientName,
                    Practitioner = a.Practitioner,
                    ReminderDate = a.AppointmentDate
                })
                .ToList();

            return View(reminders);
        }
    }
}