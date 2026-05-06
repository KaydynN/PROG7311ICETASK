using MedicalBooking.API.Interfaces;
using MedicalBooking.API.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace MedicalBooking.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AppointmentsController : ControllerBase
    {
        private readonly IAppointmentService _service;

        public AppointmentsController(IAppointmentService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_service.GetAppointments());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var appointment = _service.GetAppointments()
                .FirstOrDefault(a => a.Id == id);

            if (appointment == null)
                return NotFound();

            return Ok(appointment);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Appointment appointment)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (_service.ExistsConflict(appointment.Practitioner, appointment.AppointmentDate))
                return Conflict("Conflict detected");

            _service.BookAppointment(appointment);

            return Ok(appointment);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Appointment updated)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existing = _service.GetAppointments()
                .FirstOrDefault(a => a.Id == id);

            if (existing == null)
                return NotFound();

            var conflict = _service.GetAppointments()
                .Any(a =>
                    a.Id != id &&
                    a.Practitioner == updated.Practitioner &&
                    a.AppointmentDate == updated.AppointmentDate);

            if (conflict)
                return Conflict("Conflict detected");

            existing.PatientName = updated.PatientName;
            existing.Practitioner = updated.Practitioner;
            existing.AppointmentDate = updated.AppointmentDate;
            existing.Reason = updated.Reason;
            existing.Attended = updated.Attended;

            return Ok(existing);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existing = _service.GetAppointments()
                .FirstOrDefault(a => a.Id == id);

            if (existing == null)
                return NotFound();

            _service.CancelAppointment(id);

            return Ok();
        }
    }
}