using MedicalBooking.Web.Models;
using System.Collections.Generic;

namespace MedicalBooking.Web.Data
{
    public static class UserStore
    {
        public static List<User> Users { get; set; } = new List<User>();
    }
}