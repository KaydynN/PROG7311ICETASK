using MedicalBooking.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using System.Text.Json.Serialization;

[Authorize]
public class PractitionersController : Controller
{
    private readonly HttpClient _client;

    public PractitionersController(IHttpClientFactory factory)
    {
        _client = factory.CreateClient("MedicalAPI");
    }

    public async Task<IActionResult> Index()
    {
        var response = await _client.GetAsync("api/practitionerschedule");
        var data = await response.Content.ReadAsStringAsync();

        var schedules = JsonConvert.DeserializeObject<List<PractitionerSchedule>>(data) ?? new();

        return View(schedules);
    }

    public IActionResult Create() => View();

    [HttpPost]
    public async Task<IActionResult> Create(PractitionerSchedule schedule)
    {
        var json = JsonConvert.SerializeObject(schedule);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        await _client.PostAsync("api/practitionerschedule", content);

        return RedirectToAction("Index");
    }

    [HttpPost]
    public async Task<IActionResult> Delete(int id)
    {
        await _client.DeleteAsync($"api/practitionerschedule/{id}");
        return RedirectToAction("Index");
    }
}