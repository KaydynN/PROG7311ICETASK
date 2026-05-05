namespace MedicalBooking.Web.Models
{
    public class Reminder
    {
        public int Id { get; set; }
        public string PatientName { get; set; }
        public string Practitioner { get; set; }
        public DateTime ReminderDate { get; set; }
    }
}