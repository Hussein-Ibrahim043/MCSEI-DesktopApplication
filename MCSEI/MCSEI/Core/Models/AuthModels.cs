using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Final_Project_SHA_V1._2.Core.Models
{
    /// <summary>
    /// login request payload.
    /// </summary>
    public class LoginRequest
    {
        public string email { get; set; }
        public string password { get; set; }
    }

    /// <summary>
    /// response returned from the login API.
    /// </summary>
    public class LoginResponse
    {
        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("data")]
        public LoginData Data { get; set; } 
    }

    /// <summary>
    /// authentication data, such as the JWT token.
    /// </summary>
    public class LoginData
    {
        [JsonProperty("token")]
        public string Token { get; set; }  // JWT token used for authenticated requests
    }

    /// <summary>
    /// signup (registration) request payload.
    /// </summary>
    public class SignupRequest
    {
        public string userName { get; set; } 
        public string email { get; set; }  
        public string password { get; set; }
        public string confirmationPassword { get; set; }  
    }

    /// <summary>
    /// request payload to confirm a user's email address using a code.
    /// </summary>
    public class ConfirmEmailRequest
    {
        public string email { get; set; } 
        public string code { get; set; }
    }

    /// <summary>
    /// request to initiate a password reset process.
    /// </summary>
    public class ForgetPasswordRequest
    {
        public string email { get; set; }
    }

    /// <summary>
    /// request to validate the forget password code.
    /// </summary>
    public class ValidForgetPasswordRequest
    {
        public string email { get; set; }
        public string code { get; set; } 
    }

    /// <summary>
    /// request to reset the password.
    /// </summary>
    public class ResetPasswordRequest
    {
        public string email { get; set; }
        public string code { get; set; }
        public string password { get; set; }
        public string confirmationPassword { get; set; }
    }

    /// <summary>
    /// request to update the password for a logged-in user.
    /// </summary>
    public class UpdatePasswordRequest
    {
        public string oldPassword { get; set; }
        public string password { get; set; }  
        public string confirmationPassword { get; set; }  
    }

    /// <summary>
    /// request to change a user's role
    /// </summary>
    public class ChangeRoleRequest
    {
        public string email { get; set; }
        public string role { get; set; }
    }
}