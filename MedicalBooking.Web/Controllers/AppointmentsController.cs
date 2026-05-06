using MedicalBooking.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace MedicalBooking.Web.Controllers
{
    [Authorize]
    public class AppointmentsController : Controller
    {
        private readonly HttpClient _client;

        public AppointmentsController(IHttpClientFactory factory)
        {
            _client = factory.CreateClient("MedicalAPI");
        }

        public async Task<IActionResult> Index()
        {
            var response = await _client.GetAsync("api/appointments");

            if (!response.IsSuccessStatusCode)
                return View(new List<Appointment>());

            var data = await response.Content.ReadAsStringAsync();

            var appointments = JsonConvert.DeserializeObject<List<Appointment>>(data)
                               ?? new List<Appointment>();

            return View(appointments);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Appointment appointment)
        {
            if (!ModelState.IsValid)
                return View(appointment);

            var json = JsonConvert.SerializeObject(appointment);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _client.PostAsync("api/appointments", content);

            if (!response.IsSuccessStatusCode)
            {
                ViewBag.Error = "Could not create appointment. A conflict may exist.";
                return View(appointment);
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            var response = await _client.GetAsync($"api/appointments/{id}");

            if (!response.IsSuccessStatusCode)
                return NotFound();

            var data = await response.Content.ReadAsStringAsync();

            var appointment = JsonConvert.DeserializeObject<Appointment>(data);

            if (appointment == null)
                return NotFound();

            return View(appointment);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Appointment appointment)
        {
            if (!ModelState.IsValid)
                return View(appointment);

            var json = JsonConvert.SerializeObject(appointment);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _client.PutAsync($"api/appointments/{appointment.Id}", content);

            if (!response.IsSuccessStatusCode)
            {
                ViewBag.Error = "Could not update appointment. A conflict may exist.";
                return View(appointment);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _client.DeleteAsync($"api/appointments/{id}");

            return RedirectToAction("Index");
        }
    }
}