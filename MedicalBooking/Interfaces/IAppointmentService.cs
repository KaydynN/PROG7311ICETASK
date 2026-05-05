using MedicalBooking.API.Models;

namespace MedicalBooking.API.Interfaces
{
    public interface IAppointmentService
    {
        IEnumerable<Appointment> GetAppointments();
        void BookAppointment(Appointment appointment);
        void RescheduleAppointment(int id, DateTime newDate);
        void CancelAppointment(int id);
        bool ExistsConflict(string practitioner, DateTime date);
    }
}
