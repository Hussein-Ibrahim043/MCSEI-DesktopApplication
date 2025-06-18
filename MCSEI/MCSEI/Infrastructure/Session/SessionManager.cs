using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project_SHA_V1._2.Services
{
    public class SessionManager
    {
        /// <summary>
        /// Session JWT Token.
        /// </summary>
        public static string AuthToken { get; set; }
        
        /// <summary>
        /// Logged In user role.
        /// </summary>
        public static string Role { get; set; }

        /// <summary>
        /// Logged In user email address.
        /// </summary>
        public static string Email { get; set; }

        /// <summary>
        /// Checks if user is currently authenticated.
        /// </summary>
        public static bool IsAuthorized => !string.IsNullOrEmpty(AuthToken);

        public static void ClearSession()
        {
            AuthToken = null;
            Role = null;
            Email = null;
        }
    }
}
