using System;

namespace MedicalBooking.API.Models
{
    public class PractitionerSchedule
    {
        public int Id { get; set; }
        public string Practitioner { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
