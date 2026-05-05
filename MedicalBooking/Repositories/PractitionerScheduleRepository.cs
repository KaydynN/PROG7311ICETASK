using MedicalBooking.API.Data;
using MedicalBooking.API.Interfaces;
using MedicalBooking.API.Models;
using System.Collections.Generic;
using System.Linq;

namespace MedicalBooking.API.Repositories
{
    public class PractitionerScheduleRepository : IPractitionerScheduleRepository
    {
        public IEnumerable<PractitionerSchedule> GetAll()
            => InMemoryAppointmentStore.Schedules;

        public void Add(PractitionerSchedule schedule)
        {
            schedule.Id = InMemoryAppointmentStore.Schedules.Count + 1;
            InMemoryAppointmentStore.Schedules.Add(schedule);
        }

        public void Update(int id, PractitionerSchedule schedule)
        {
            var existing = InMemoryAppointmentStore.Schedules
                .FirstOrDefault(s => s.Id == id);

            if (existing == null) return;

            existing.Practitioner = schedule.Practitioner;
            existing.StartTime = schedule.StartTime;
            existing.EndTime = schedule.EndTime;
        }

        public void Delete(int id)
        {
            var schedule = InMemoryAppointmentStore.Schedules
                .FirstOrDefault(s => s.Id == id);

            if (schedule != null)
                InMemoryAppointmentStore.Schedules.Remove(schedule);
        }
    }
}