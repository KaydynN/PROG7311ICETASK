using MedicalBooking.API.Models;
using System.Collections.Generic;

namespace MedicalBooking.API.Data
{
    public static class InMemoryAppointmentStore
    {
        public static List<Appointment> Appointments { get; set; } = new();
        public static List<PractitionerSchedule> Schedules { get; set; } = new();
    }
}
