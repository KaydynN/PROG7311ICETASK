using MedicalBooking.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using System.Text.Json.Serialization;

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

        var data = await response.Content.ReadAsStringAsync();
        var appointments = JsonConvert.DeserializeObject<List<Appointment>>(data) ?? new();

        return View(appointments);
    }

    public IActionResult Create() => View();

    [HttpPost]
    public async Task<IActionResult> Create(Appointment appointment)
    {
        var json = JsonConvert.SerializeObject(appointment);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        await _client.PostAsync("api/appointments", content);

        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Edit(int id)
    {
        var response = await _client.GetAsync($"api/appointments/{id}");

        if (!response.IsSuccessStatusCode)
            return NotFound();

        var data = await response.Content.ReadAsStringAsync();
        var appt = JsonConvert.DeserializeObject<Appointment>(data);

        return View(appt);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Appointment appointment)
    {
        var json = JsonConvert.SerializeObject(appointment);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        await _client.PutAsync($"api/appointments/{appointment.Id}", content);

        return RedirectToAction("Index");
    }
    [HttpPost]
    public async Task<IActionResult> Delete(int id)
    {
        await _client.DeleteAsync($"api/appointments/{id}");
        return RedirectToAction("Index");
    }
}