using MedicalBooking.API.Models;

namespace MedicalBooking.API.Interfaces
{
    public interface IReminderService
    {
        void SendReminder(Appointment appointment);
    }
}