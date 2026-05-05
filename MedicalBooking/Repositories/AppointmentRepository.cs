using MedicalBooking.API.Data;
using MedicalBooking.API.Interfaces;
using MedicalBooking.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MedicalBooking.API.Repositories
{
    public class AppointmentRepository : IAppointmentRepository
    {
        public IEnumerable<Appointment> GetAll() => InMemoryAppointmentStore.Appointments;

        public Appointment GetById(int id) =>
            InMemoryAppointmentStore.Appointments.FirstOrDefault(a => a.Id == id);

        public void Add(Appointment appointment)
        {
            appointment.Id = InMemoryAppointmentStore.Appointments.Count + 1;
            InMemoryAppointmentStore.Appointments.Add(appointment);
        }

        public void Update(Appointment appointment)
        {
            var existing = GetById(appointment.Id);
            if (existing == null) return;

            existing.PatientName = appointment.PatientName;
            existing.Practitioner = appointment.Practitioner;
            existing.AppointmentDate = appointment.AppointmentDate;
            existing.Attended = appointment.Attended;
            existing.Reason = appointment.Reason;
        }

        public void Delete(int id)
        {
            var appt = GetById(id);
            if (appt != null)
                InMemoryAppointmentStore.Appointments.Remove(appt);
        }

        public bool ExistsConflict(string practitioner, DateTime date)
        {
            return InMemoryAppointmentStore.Appointments
                .Any(a => a.Practitioner == practitioner && a.AppointmentDate == date);
        }
    }
}