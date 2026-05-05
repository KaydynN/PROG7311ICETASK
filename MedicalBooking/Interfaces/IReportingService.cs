using MedicalBooking.API.Models;

namespace MedicalBooking.API.Interfaces
{
    public interface IReportingService
    {
        AppointmentReport GenerateReport();
    }
}
