using System;

namespace MedicalBooking.Web.Models
{
    public class PractitionerSchedule
    {
        public int Id { get; set; }
        public string Practitioner { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
