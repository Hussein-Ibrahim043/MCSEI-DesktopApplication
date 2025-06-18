using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Final_Project_SHA_V1._2.Core.Interfaces;
using Final_Project_SHA_V1._2.Core.Models;
using Final_Project_SHA_V1._2.Infrastructure.Utils;
using FinalProject_MedicalSystem.Infrastructure.Http;
using Infrastructure.Http;

namespace Final_Project_SHA_V1._2.Services
{
    /// <summary>
    /// Service responsible for handling medical record operations (Create, Read, Update, Delete).
    /// </summary>
    public class MedicalService : IMedicalService
    {
        private static readonly HttpClient client = new HttpClient();
        private static readonly string URL = "https://medical-website-three-delta.vercel.app";

        // Static constructor to initialize base address for HttpClient.
        static MedicalService()
        {
            client.BaseAddress = new Uri(URL);
        }

        /// <summary>
        /// Ensures a valid bearer token is set for authorization.
        /// Throws an UnauthorizedAccessException if the token is missing.
        /// </summary>
        private static void EnsureAuthorization()
        {
            if (string.IsNullOrEmpty(SessionManager.AuthToken))
                throw new UnauthorizedAccessException("No token found. Please login again.");

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", SessionManager.AuthToken);
        }

        /// <summary>
        /// Create a new medical record.
        /// </summary>
        public async Task<bool> CreateMedicalRecordAsync(CreateMedicalRequest medicalRecord)
        {
            try
            {
                EnsureAuthorization();

                var response = await RequestHandler.PostAsync<HttpResponseMessage>(
                    ApiEndpoints.CreateMedicalRecord, medicalRecord);

                if (!response.IsSuccessStatusCode)
                {
                    Logger.LogInfo($"Medical record creation failed: {response.Content}");
                    return false;
                }

                Logger.LogInfo("Medical record created successfully.");
                return true;
            }
            catch (Exception ex)
            {
                Logger.LogError("Error in CreateMedicalRecordAsync", ex);
                throw;
            }
        }

        /// <summary>
        /// Fetches all medical records for a given citizen by National ID.
        /// </summary>
        public async Task<MedicalApiResponse> GetMedicalRecordsAsync(string nationalId)
        {
            try
            {
                EnsureAuthorization();

                if (string.IsNullOrWhiteSpace(nationalId))
                    throw new ArgumentException("National ID must not be empty.");

                var result = await RequestHandler.GetAsync<MedicalApiResponse>(
                    ApiEndpoints.MedicalRecordById(nationalId));

                if (result == null)
                    throw new Exception("No medical record found for the provided National ID.");

                return result;
            }
            catch (Exception ex)
            {
                Logger.LogError("Error in GetMedicalRecordsAsync", ex);
                throw;
            }
        }

        /// <summary>
        /// Updates an existing medical record using the National ID and record ID.
        /// </summary>        
        public async Task<bool> UpdateMedicalRecordAsync(MedicalRequest medicalRecord, string _ID)
        {
            try
            {
                EnsureAuthorization();

                if (medicalRecord == null || string.IsNullOrEmpty(_ID))
                    throw new ArgumentNullException(nameof(medicalRecord), "Medical record data is required.");                

                string endpoint = ApiEndpoints.UpdateMedicalRecord(medicalRecord.NationalID, _ID);

                var response = await RequestHandler.PatchAsync<HttpResponseMessage>(endpoint, medicalRecord);
                if (!response.IsSuccessStatusCode)
                {
                    Logger.LogError($"Medical record Update failed: {response.Content}");
                    return false;
                }

                Logger.LogInfo($"Medical record {_ID} for {medicalRecord.NationalID} updated successfully.\n");
                return true;
            }
            catch (Exception ex)
            {
                Logger.LogError("Error in UpdateMedicalRecordAsync", ex);
                throw;
            }
        }

        /// <summary>
        /// Deletes a specific medical record by National ID and record ID.
        /// </summary>
        public async Task<bool> DeleteMedicalRecordAsync(string nationalId, string _id)
        {
            try
            {
                EnsureAuthorization();

                if (string.IsNullOrWhiteSpace(nationalId) || string.IsNullOrWhiteSpace(_id))
                    throw new ArgumentException("National ID or record ID cannot be null or empty.");

                string endpoint = ApiEndpoints.DeleteMedicalRecord(nationalId, _id);

                var response = await RequestHandler.DeleteAsync<HttpResponseMessage>(endpoint);
                if (!response.IsSuccessStatusCode)
                {
                    Logger.LogError($"Failed to delete medical record with ID {_id} for National ID {nationalId}.\n");
                    Logger.LogError($"Medical record Deletion failed: {response.Content}");
                    return false;
                }

                Logger.LogInfo($"Deleted medical record {_id} for {nationalId}");
                return true;
            }
            catch (Exception ex)
            {
                Logger.LogError("Error in DeleteMedicalRecordAsync", ex);
                throw;
            }
        }
    }
}

