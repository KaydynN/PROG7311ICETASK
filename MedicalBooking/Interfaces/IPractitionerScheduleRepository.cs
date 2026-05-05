using MedicalBooking.API.Models;
using System.Collections.Generic;

namespace MedicalBooking.API.Interfaces
{
    public interface IPractitionerScheduleRepository
    {
        IEnumerable<PractitionerSchedule> GetAll();
        void Add(PractitionerSchedule schedule);
        void Update(int id, PractitionerSchedule schedule);
        void Delete(int id);
    }
}

