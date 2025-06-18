using System;
using System.Net.Http;
using System.Threading.Tasks;
using Final_Project_SHA_V1._2.Core.Interfaces;
using Final_Project_SHA_V1._2.Core.Models;
using Final_Project_SHA_V1._2.Infrastructure.Utils;
using FinalProject_MedicalSystem.Infrastructure.Http;
using Infrastructure.Http;

namespace Final_Project_SHA_V1._2.Services
{
    public class AuthService : IAuthService
    {
        private static readonly HttpClient client = new HttpClient();
        private static readonly string URL = "https://medical-website-three-delta.vercel.app";

        static AuthService()
        {
            client.BaseAddress = new Uri(URL);
        }

        /// <summary>
        /// Logs in user with email and password, returns LoginResponse with token & role.
        /// </summary>
        public async Task<bool> LoginAsync(string email, string password)
        {
            try
            {
                // 1. Validate input
                if (!Validator.IsValidEmail(email))
                {
                    Logger.LogError("Login attempt with invalid email format: " + email);
                    return false;
                }

                if (string.IsNullOrWhiteSpace(password))
                {
                    Logger.LogError("Login attempt with empty password");
                    return false;
                }

                // 2. Prepare the LoginRequest model
                var loginRequest = new LoginRequest
                {
                    email = email,
                    password = password
                };

                // 3. Call API
                LoginResponse loginResponse = await RequestHandler.PostAsync<LoginResponse>(
                    ApiEndpoints.Login, loginRequest
                );

                if (loginResponse?.Data?.Token == null)
                {
                    Logger.LogInfo("Login failed: No token returned for user " + email);
                    return false;
                }

                // 4. Store token in session
                SessionManager.AuthToken = loginResponse.Data.Token;

                // 5. Decode and store user info
                TokenHelper.StoreRoleInSession(SessionManager.AuthToken);
                TokenHelper.StoreEmailInSession(SessionManager.AuthToken);

                Logger.LogInfo($"User '{email}' logged in with role: {SessionManager.Role}");

                return true;
            }
            catch (Exception ex)
            {
                Logger.LogError("Exception during login for user: " + email, ex);
                return false;
            }
        }

        /// <summary>
        /// Sign up a new user.
        /// </summary>
        public async Task<bool> SignupAsync(string fullName, string email, string password, string confirmationPassword)
        {
            try
            {
                //Validate input
                if (!Validator.IsValidEmail(email))
                {
                    Logger.LogInfo("Signup attempt with invalid email format: " + email);
                    return false;
                }

                if (string.IsNullOrWhiteSpace(password) || password.Length < 6)
                {
                    Logger.LogInfo("Signup attempt with invalid or too short password");
                    return false;
                }

                //Create SignupRequest model
                var signupRequest = new SignupRequest
                {
                    userName = fullName,
                    email = email,
                    password = password,
                    confirmationPassword = confirmationPassword
                };

                //Send request
                HttpResponseMessage isRegistered = await RequestHandler.PostAsync<HttpResponseMessage>(
                    ApiEndpoints.Signup, signupRequest
                );

                if (isRegistered.IsSuccessStatusCode)
                {
                    Logger.LogInfo("User signed up successfully: " + email);
                    return true;
                }
                else
                {
                    Logger.LogError("Signup failed for user: " + email);
                    return false;
                }                
            }
            catch (Exception ex)
            {
                Logger.LogError("Exception during signup for user: " + email, ex);
                return false;
            }
        }

        /// <summary>
        /// Confirm email with code.
        /// </summary>
        public async Task<bool> ConfirmEmailAsync(string email, string code)
        {
            try
            {
                //Validate inputs
                if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(code))
                {
                    Logger.LogInfo("ConfirmEmail called with empty email or code");
                    return false;
                }

                //Prepare the request model
                var confirmRequest = new ConfirmEmailRequest
                {
                    email = email,
                    code = code
                };

                //Send request
                HttpResponseMessage isConfirmed = await RequestHandler.PostAsync<HttpResponseMessage>(
                    ApiEndpoints.ConfirmEmail, confirmRequest
                );

                //Log result
                if (isConfirmed.IsSuccessStatusCode)
                {
                    Logger.LogInfo($"Email confirmed successfully for: {email}");
                    return true;
                }
                else
                {
                    Logger.LogError($"Email confirmation failed for: {email}");

                    return false;
                }

            }
            catch (Exception ex)
            {
                Logger.LogError($"Exception during email confirmation for: {email}", ex);
                return false;
            }
        }

        /// <summary>
        /// Request password reset code.
        /// </summary>
        public async Task<bool> ForgetPasswordAsync(string email)
        {
            try
            {
                //Validate email
                if (string.IsNullOrWhiteSpace(email) || !Validator.IsValidEmail(email))
                {
                    Logger.LogInfo("ForgetPassword called with invalid or empty email: " + email);
                    return false;
                }

                //Prepare the request
                var request = new ForgetPasswordRequest
                {
                    email = email
                };

                //Call the API
                HttpResponseMessage isSent = await RequestHandler.PostAsync<HttpResponseMessage>(
                    ApiEndpoints.ForgetPassword, request
                );

                //Log result
                if (isSent.IsSuccessStatusCode)
                {
                    Logger.LogInfo("Password reset email sent successfully to: " + email);
                    return true;
                }
                else
                {
                    Logger.LogInfo("Failed to send password reset email to: " + email);

                    return false;
                }

            }
            catch (Exception ex)
            {
                Logger.LogError("Exception during forget password process for email: " + email, ex);
                return false;
            }
        }

        /// <summary>
        /// Validate forget password service.
        /// </summary>
        public async Task<bool> ValidateForgetPasswordAsync(string email, string code)
        {
            try
            {
                //Validate input
                if (string.IsNullOrWhiteSpace(email) || !Validator.IsValidEmail(email))
                {
                    Logger.LogInfo("ValidateForgetPassword called with invalid or empty email: " + email);
                    return false;
                }

                if (string.IsNullOrWhiteSpace(code))
                {
                    Logger.LogInfo("ValidateForgetPassword called with empty code");
                    return false;
                }

                //Prepare request
                var request = new ValidForgetPasswordRequest
                {
                    email = email,
                    code = code
                };

                //Send request
                HttpResponseMessage isValid = await RequestHandler.PostAsync<HttpResponseMessage>(
                    ApiEndpoints.ValidForgetPassword, request
                );

                //Log result
                if (isValid.IsSuccessStatusCode)
                {
                    Logger.LogInfo($"ValidateForgetPassword succeeded for email: {email}");
                    return true;
                }
                else
                {
                    Logger.LogInfo($"ValidateForgetPassword failed for email: {email}");

                    return false;
                }

            }
            catch (Exception ex)
            {
                Logger.LogError("Exception during ValidateForgetPassword for email: " + email, ex);
                return false;
            }
        }

        /// <summary>
        /// Reset password service.
        /// </summary>
        public async Task<bool> ResetPasswordAsync(string email, string code, string password, string confirmationPassword)
        {
            try
            {
                //Validate input
                if (string.IsNullOrWhiteSpace(email) || !Validator.IsValidEmail(email))
                {
                    Logger.LogInfo("ResetPassword called with invalid email: " + email);
                    return false;
                }

                if (string.IsNullOrWhiteSpace(code))
                {
                    Logger.LogInfo("ResetPassword called with empty code");
                    return false;
                }

                if (string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(confirmationPassword))
                {
                    Logger.LogInfo("ResetPassword called with empty password or confirmation");
                    return false;
                }

                if (password != confirmationPassword)
                {
                    Logger.LogInfo("ResetPassword called with non-matching passwords");
                    return false;
                }
                

                //Prepare request
                var resetRequest = new ResetPasswordRequest
                {
                    email = email,
                    code = code,
                    password = password,
                    confirmationPassword = confirmationPassword
                };

                //Send request
                HttpResponseMessage success = await RequestHandler.PostAsync<HttpResponseMessage>(ApiEndpoints.ResetPassword, resetRequest);

                //Log result
                if (success.IsSuccessStatusCode)
                {
                    Logger.LogInfo($"Password reset successfully for: {email}");
                    return true;
                }
                else
                {
                    Logger.LogInfo($"Password reset failed for: {email}");

                    return false;
                }

            }
            catch (Exception ex)
            {
                Logger.LogError("Exception during ResetPassword for email: " + email, ex);
                return false;
            }
        }

        /// <summary>
        /// Update password while logged in service.
        /// </summary>
        public async Task<bool> UpdatePasswordAsync(string oldPassword, string password, string confirmationPassword)
        {
            try
            {
                //Input validation
                if (string.IsNullOrWhiteSpace(oldPassword))
                {
                    Logger.LogInfo("UpdatePassword called with empty current password");
                    return false;
                }

                if (string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(confirmationPassword))
                {
                    Logger.LogInfo("UpdatePassword called with empty new password or confirmation");
                    return false;
                }

                if (password != confirmationPassword)
                {
                    Logger.LogInfo("UpdatePassword failed: passwords do not match");
                    return false;
                }

                if (password == oldPassword)
                {
                    Logger.LogInfo("UpdatePassword failed: new password is the same as current password");
                    return false;
                }
                
                //Prepare request
                var request = new UpdatePasswordRequest
                {
                    oldPassword = oldPassword,
                    password = password,
                    confirmationPassword = confirmationPassword
                };

                //Send request
                HttpResponseMessage success = await RequestHandler.PostAsync<HttpResponseMessage>(ApiEndpoints.UpdatePassword, request);

                //Log result
                if (success.IsSuccessStatusCode)
                {
                    Logger.LogInfo($"Password updated successfully for: {SessionManager.Email}");
                    return true;
                }
                else
                {
                    Logger.LogInfo($"Password update failed for: {SessionManager.Email}");

                    return false;
                }

            }
            catch (Exception ex)
            {
                Logger.LogError("Exception during UpdatePassword for email: " + SessionManager.Email, ex);
                return false;
            }
        }
        /// <summary>
        /// Change Role service
        /// </summary>        
        public async Task<bool> ChangeRoleAsync(string email, string role)
        {
            try
            {
                //Input Validation
                if (SessionManager.Role != "Admin")
                {
                    Logger.LogInfo("Unauthorized attempt to change role");
                    return false;
                }

                if (string.IsNullOrWhiteSpace(email) || !Validator.IsValidEmail(email))
                {
                    Logger.LogInfo("ChangeRole called with invalid or empty email: " + email);
                    return false;
                }

                if (string.IsNullOrWhiteSpace(role) || !Validator.IsValidRole(role))
                {
                    Logger.LogInfo("ChangeRole called with invalid or empty role: " + role);
                    return false;
                }

                //Prepare request
                var request = new ChangeRoleRequest
                {
                    email = email,
                    role = role
                };

                //Send request
                HttpResponseMessage success = await RequestHandler.PatchAsync<HttpResponseMessage>(ApiEndpoints.ChangeRole, request);
                //Log result
                if (success.IsSuccessStatusCode)
                {
                    Logger.LogInfo("Role changed successfully for: " + email);
                    return true;
                }
                else
                {
                    Logger.LogInfo("Failed to change role for: " + email);

                    return false;
                }

            }
            catch (Exception ex)
            {
                Logger.LogError("Exception during ChangeRole for email: " + email, ex);
                return false;
            }
        }

        /// <summary>
        /// Clears the stored authentication token (logs out).
        /// </summary>
        public void Logout()
        {
            try
            {
                SessionManager.ClearSession();
                Logger.LogInfo("User logged out successfully.");
            }
            catch (Exception ex)
            {
                Logger.LogError("Exception during logout", ex);
                throw; 
            }
        }
    }
}
