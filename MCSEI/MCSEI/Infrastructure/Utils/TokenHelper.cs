using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Final_Project_SHA_V1._2.Services;

namespace Final_Project_SHA_V1._2.Infrastructure.Utils
{
    public static class TokenHelper
    {
        // Decode JWT token.
        public static ClaimsPrincipal DecodeJwt(string token)
        {
            if (string.IsNullOrEmpty(token)) return null;

            var handler = new JwtSecurityTokenHandler();
            try
            {
                var jwtToken = handler.ReadJwtToken(token);
                var identity = new ClaimsIdentity(jwtToken.Claims);
                return new ClaimsPrincipal(identity);
            }
            catch
            {
                return null;
            }
        }

        public static string GetClaimValue(string token, string claimType)
        {
            var principal = DecodeJwt(token);
            if (principal == null) return null;

            var claim = principal.FindFirst(claimType);
            return claim?.Value;
        }

        // Extract 'role' and store in session manager
        public static void StoreRoleInSession(string token)
        {
            string role = GetClaimValue(token, "role");
            if (!string.IsNullOrEmpty(role))
            {
                SessionManager.Role = role;
            }
        }

        // Extract 'Email' and store in session manager
        public static void StoreEmailInSession(string token)
        {
            string email = GetClaimValue(token, "email");
            if (!string.IsNullOrEmpty(email))
            {
                SessionManager.Email = email;
            }
        }
    }
}
