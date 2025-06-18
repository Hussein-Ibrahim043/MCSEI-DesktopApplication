using System;
using System.Net.Http;
using System.Threading.Tasks;
using Final_Project_SHA_V1._2.Core.Models;
using Final_Project_SHA_V1._2.Core.Interfaces;
using FinalProject_MedicalSystem.Infrastructure.Http;
using Infrastructure.Http;
using Final_Project_SHA_V1._2.Infrastructure.Utils;

namespace Final_Project_SHA_V1._2.Services
{
    /// <summary>
    /// Service for handling operations related to Citizen records (CRUD).
    /// </summary>
    public class CitizenService : ICitizenService
    {
        private static readonly HttpClient client = new HttpClient();
        public static string URL = "https://medical-website-three-delta.vercel.app";

        /// <summary>
        /// Ensures that a valid Auth token is set before making any API requests.
        /// </summary>
        private static void EnsureAuthorization()
        {
            if (string.IsNullOrEmpty(SessionManager.AuthToken))
                throw new Exception("No token found. Please login again.");
        }

        /// <summary>
        /// Validates the data of a citizen request using format rules (e.g., NID and phone number).
        /// </summary>
        private bool ValidateCitizenRequest(CitizenRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.NID) ||
                string.IsNullOrWhiteSpace(request.FullName) ||
                string.IsNullOrWhiteSpace(request.Address) ||
                string.IsNullOrWhiteSpace(request.BloodType) ||
                string.IsNullOrWhiteSpace(request.BirthDate) ||
                string.IsNullOrWhiteSpace(request.MobileNumber))
            {
                return false;
            }

            return Validator.IsValidNationalID(request.NID) && Validator.IsValidPhone(request.MobileNumber);
        }

        /// <summary>
        /// Sends a POST request to create a new citizen record.
        /// </summary>
        public async Task<bool> CreateCitizenRecordAsync(string NID, string FullName, string Address, string BloodType, string BirthDate, string Phone)
        {
            try
            {
                EnsureAuthorization();

                var request = new CitizenRequest
                {
                    NID = NID,
                    FullName = FullName,
                    Address = Address,
                    BloodType = BloodType,
                    BirthDate = BirthDate,
                    MobileNumber = Phone
                };

                if (!ValidateCitizenRequest(request))
                {
                    Logger.LogInfo("Citizen validation failed during creation.");
                    return false;
                }

                var result = await RequestHandler.PostAsync<HttpResponseMessage>(ApiEndpoints.CreateCitizenRecord, request);

                if (result.IsSuccessStatusCode)
                {
                    Logger.LogInfo($"Citizen Record Created successfully: {NID}");
                    return true;
                }
                else
                {
                    Logger.LogError($"Failed to create citizen record: {NID}");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError("Exception in CreateCitizenAsync", ex);
                return false;
            }
        }

        /// <summary>
        /// Fetches citizen information by their National ID.
        /// </summary>
        public async Task<CitizenRecordResponse> GetCitizenByNationalIdAsync(string nationalId)
        {
            try
            {
                EnsureAuthorization();

                if (!Validator.IsValidNationalID(nationalId))
                {
                    Logger.LogInfo("Invalid or empty national ID for fetch.");
                    return null;
                }

                string endpoint = ApiEndpoints.FindCitizenByNationalID(nationalId);
                var citizen = await RequestHandler.GetAsync<CitizenRecordResponse>(endpoint);

                Logger.LogInfo(citizen != null
                    ? $"Fetched citizen: {nationalId}"
                    : $"No citizen found with ID: {nationalId}");

                return citizen;
            }
            catch (Exception ex)
            {
                Logger.LogError("Exception during GetCitizenByNationalIdAsync", ex);
                return null;
            }
        }

        /// <summary>
        /// Updates a citizen record by National ID.
        /// </summary>
        public async Task<bool> UpdateCitizenAsync(string NID, string FullName, string Address, string BloodType, string BirthDate, string Phone)
        {
            try
            {
                EnsureAuthorization();

                var citizen = new CitizenRequest
                {
                    NID = NID,
                    FullName = FullName,
                    Address = Address,
                    BloodType = BloodType,
                    BirthDate = BirthDate,
                    MobileNumber = Phone
                };

                if (!ValidateCitizenRequest(citizen))
                {
                    Logger.LogInfo("Citizen validation failed during update.");
                    return false;
                }

                string endpoint = ApiEndpoints.UpdateCitizenRecord(NID);
                HttpResponseMessage response = await RequestHandler.PatchAsync<HttpResponseMessage>(endpoint, citizen);
                if (response.IsSuccessStatusCode)
                {
                    Logger.LogInfo($"Citizen Record Updated successfully: {NID}");
                    return true;
                }
                else
                {
                    Logger.LogError($"Failed to update citizen record: {NID}");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError("Exception during UpdateCitizenAsync", ex);
                return false;
            }
        }

        /// <summary>
        /// Deletes a citizen record by National ID.
        /// </summary>
        public async Task<bool> DeleteCitizenAsync(string nationalId)
        {
            try
            {
                EnsureAuthorization();

                if (!Validator.IsValidNationalID(nationalId) || string.IsNullOrWhiteSpace(nationalId))
                {
                    Logger.LogInfo("Invalid or empty national ID for deletion.");
                    return false;
                }

                string endpoint = ApiEndpoints.DeleteCitizenRecord(nationalId);
                HttpResponseMessage response = await RequestHandler.DeleteAsync<HttpResponseMessage>(endpoint);

                if (response.IsSuccessStatusCode)
                {
                    Logger.LogInfo($"Citizen Record Deleted successfully: {nationalId}");
                    return true;
                }
                else
                {
                    Logger.LogError($"Failed to delete citizen record: {nationalId}");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError("Exception during DeleteCitizenAsync", ex);
                return false;
            }
        }
    }
}
