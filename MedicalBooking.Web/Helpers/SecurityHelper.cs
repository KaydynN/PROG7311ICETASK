using System.Security.Cryptography;
using System.Text;

namespace MedicalBooking.Web.Helpers
{
    public static class SecurityHelper
    {
        public static string Hash(string input)
        {
            using var sha = SHA256.Create();
            var bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(input));
            return Convert.ToBase64String(bytes);
        }
    }
}
