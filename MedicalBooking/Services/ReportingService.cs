using MedicalBooking.API.Interfaces;
using MedicalBooking.API.Models;
using System;
using System.Linq;

namespace MedicalBooking.API.Services
{
    public class ReportingService : IReportingService
    {
        public AppointmentReport GenerateReport()
        {
            var appointments = MedicalBooking.API.Data.InMemoryAppointmentStore.Appointments;

            return new AppointmentReport
            {
                TotalAppointments = appointments.Count,
                AttendedCount = appointments.Count(a => a.Attended),
                MissedCount = appointments.Count(a => a.AppointmentDate < DateTime.Now && !a.Attended),
                PendingCount = appointments.Count(a => a.AppointmentDate >= DateTime.Now && !a.Attended),
                AppointmentsPerPractitioner = appointments
                    .GroupBy(a => a.Practitioner)
                    .ToDictionary(g => g.Key, g => g.Count())
            };
        }
    }
}