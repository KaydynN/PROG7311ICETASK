using MedicalBooking.API.Interfaces;
using MedicalBooking.API.Models;
using Microsoft.Extensions.Logging;

namespace MedicalBooking.API.Services
{
    public class ReminderService : IReminderService
    {
        private readonly ILogger<ReminderService> _logger;

        public ReminderService(ILogger<ReminderService> logger)
        {
            _logger = logger;
        }

        public void SendReminder(Appointment appointment)
        {
            _logger.LogInformation(
                $"[REMINDER] {appointment.PatientName} has an appointment with {appointment.Practitioner} at {appointment.AppointmentDate}");
        }
    }
}