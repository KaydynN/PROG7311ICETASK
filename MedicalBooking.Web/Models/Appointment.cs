using System;

namespace MedicalBooking.Web.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public string PatientName { get; set; }
        public string Practitioner { get; set; }
        public DateTime AppointmentDate { get; set; }
        public bool Attended { get; set; }
        public string Reason { get; set; } // Added Reason field
    }
}
