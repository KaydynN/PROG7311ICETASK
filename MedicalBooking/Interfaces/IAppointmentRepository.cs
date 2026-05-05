using MedicalBooking.API.Models;
using System;
using System.Collections.Generic;

namespace MedicalBooking.API.Interfaces
{
    public interface IAppointmentRepository
    {
        IEnumerable<Appointment> GetAll();
        Appointment GetById(int id);
        void Add(Appointment appointment);
        void Update(Appointment appointment);
        void Delete(int id);
        bool ExistsConflict(string practitioner, DateTime date);
    }
}
