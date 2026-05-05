using System;
using System.ComponentModel.DataAnnotations;

namespace MedicalBooking.API.Models
{
    public class Appointment
    {
        public int Id { get; set; }

        [Required]
        public string PatientName { get; set; }

        [Required]
        public string Practitioner { get; set; }

        [Required]
        public DateTime AppointmentDate { get; set; }

        public bool Attended { get; set; }

        public string Reason { get; set; }

        
        public bool ReminderSent { get; set; } = false;
    }
}
