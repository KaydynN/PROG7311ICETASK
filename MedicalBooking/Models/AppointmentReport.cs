namespace MedicalBooking.API.Models
{
    public class AppointmentReport
    {
        public int TotalAppointments { get; set; }
        public int AttendedCount { get; set; }
        public int MissedCount { get; set; }
        public int PendingCount { get; set; }  // new

        public Dictionary<string, int> AppointmentsPerPractitioner { get; set; } = new();
    }
}