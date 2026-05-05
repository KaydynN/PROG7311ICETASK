using MedicalBooking.API.Interfaces;
using MedicalBooking.API.Models;
using System;
using System.Collections.Generic;

namespace MedicalBooking.API.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _repository;
        private readonly IReminderService _reminder;

        public AppointmentService(IAppointmentRepository repository, IReminderService reminder)
        {
            _repository = repository;
            _reminder = reminder;
        }

        public IEnumerable<Appointment> GetAppointments() => _repository.GetAll();

        public void BookAppointment(Appointment appointment)
        {
            _repository.Add(appointment);
            _reminder.SendReminder(appointment);
        }

        public void RescheduleAppointment(int id, DateTime newDate)
        {
            var appt = _repository.GetById(id);
            if (appt != null)
            {
                appt.AppointmentDate = newDate;
                _repository.Update(appt);
                _reminder.SendReminder(appt);
            }
        }

        public void CancelAppointment(int id)
        {
            _repository.Delete(id);
        }

        public bool ExistsConflict(string practitioner, DateTime date)
            => _repository.ExistsConflict(practitioner, date);
    }
}