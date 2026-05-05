using System.Collections.Generic;

namespace MedicalBooking.Web.Models
{
    public class AppointmentReport
    {
        public int TotalAppointments { get; set; }
        public int AttendedCount { get; set; }
        public int MissedCount { get; set; }

        // Add PendingCount
        public int PendingCount { get; set; }

        // Add AppointmentsPerPractitioner
        public Dictionary<string, int> AppointmentsPerPractitioner { get; set; } = new();
    }
}
