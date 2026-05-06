using MedicalBooking.API.Interfaces;
using MedicalBooking.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace MedicalBooking.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PractitionerScheduleController : ControllerBase
    {
        private readonly IPractitionerScheduleRepository _repo;

        public PractitionerScheduleController(IPractitionerScheduleRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_repo.GetAll());
        }

        [HttpPost]
        public IActionResult Create([FromBody] PractitionerSchedule schedule)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _repo.Add(schedule);

            return Ok(schedule);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] PractitionerSchedule schedule)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _repo.Update(id, schedule);

            return Ok(schedule);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _repo.Delete(id);

            return Ok();
        }
    }
}