    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Final_Project_SHA_V1._2.Infrastructure.Utils
{
    public static class Validator
    {
        // Validate email format
        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email)) return false;
            try
            {
                var pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
                return Regex.IsMatch(email, pattern, RegexOptions.IgnoreCase);
            }
            catch
            {
                return false;
            }
        }

        // Validate phone number (simple pattern, customize as needed)
        public static bool IsValidPhone(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone)) return false;
            var pattern = @"^\+?\d{7,15}$";  // allows optional + and 7-15 digits
            return Regex.IsMatch(phone, pattern);
        }

        // Validate Egyptian National ID (14 digits numeric)
        public static bool IsValidNationalID(string id)
        {
            if (string.IsNullOrWhiteSpace(id)) return false;
            var pattern = @"^\d{14}$";
            return Regex.IsMatch(id, pattern);
        }

        // Validate non-empty string
        public static bool IsNonEmpty(string input)
        {
            return !string.IsNullOrWhiteSpace(input);
        }

        

        public static bool IsValidBloodType(string bloodType)
        {
            string[] validTypes = { "A+", "A-", "B+", "B-", "AB+", "AB-", "O+", "O-" };
            return Array.Exists(validTypes, type => type == bloodType.ToUpper());
        }

        private static readonly List<string> AllowedRoles = new List<string>
    {
        "Admin",
        "Doctor",
        "User"        
        // Add more if needed
    };

        public static bool IsValidRole(string role)
        {
            if (string.IsNullOrWhiteSpace(role))
                return false;

            return AllowedRoles.Contains(role.Trim().ToLower());
        }
    }
}
