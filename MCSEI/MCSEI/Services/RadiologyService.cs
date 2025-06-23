using System;
using System.IO;
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
    /// Service class responsible for managing radiology records via HTTP requests to the backend API.
    /// </summary>
    public class RadiologyService : IRadiologyService
    {
        private static readonly HttpClient client = new HttpClient();
        private static readonly string URL = "https://mcsei-production.up.railway.app";

        // Static constructor to initialize HttpClient base URL
        static RadiologyService()
        {
            client.BaseAddress = new Uri(URL);
        }

        /// <summary>
        /// Ensures the authorization token is set in the request headers.
        /// </summary>
        private static void EnsureAuthorization()
        {
            if (string.IsNullOrEmpty(SessionManager.AuthToken))
                throw new Exception("No token found. Please login again.");

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", SessionManager.AuthToken);
        }

        /// <summary>
        /// Creates a new radiology record for the specified national ID.
        /// </summary>
        public async Task<bool> CreateRadiologyRecordAsync(string nationalId, string radiologyType, string notes, string imagePath)
        {
            try
            {
                // Validate required fields
                if (!Validator.IsValidNationalID(nationalId) || !Validator.IsNonEmpty(radiologyType))
                {
                    Logger.LogInfo("Invalid input for CreateRadiologyRecordAsync");
                    return false;
                }

                EnsureAuthorization();

                using (var content = new MultipartFormDataContent())
                {
                    // Add form data
                    content.Add(new StringContent(nationalId), "national_ID");
                    content.Add(new StringContent(radiologyType), "radiology_type");
                    content.Add(new StringContent(notes ?? ""), "radiologistNotes");

                    // Attach image if provided
                    if (!string.IsNullOrEmpty(imagePath) && File.Exists(imagePath))
                    {
                        var imageBytes = File.ReadAllBytes(imagePath);
                        var fileContent = new ByteArrayContent(imageBytes);
                        fileContent.Headers.ContentType = new MediaTypeHeaderValue("image/jpeg");
                        content.Add(fileContent, "images", Path.GetFileName(imagePath));
                    }

                    // Send POST request
                    HttpResponseMessage response = await RequestHandler.PostRadiologyAsync<HttpResponseMessage>(ApiEndpoints.CreateRadiology, content);
                    if (!response.IsSuccessStatusCode)
                    {
                        Logger.LogError($"Radiology record creation failed: {response.Content}");
                        return false;
                    }

                    Logger.LogInfo($"Radiology record created successfully for NationalID: {nationalId}");
                    return true;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError("Error in CreateRadiologyRecordAsync", ex);
                return false;
            }
        }

        /// <summary>
        /// Retrieves all radiology records associated with a given national ID.
        /// </summary>
        public async Task<RadiologyApiResponse> GetRadiologyRecordsAsync(string nationalId)
        {
            try
            {
                if (!Validator.IsValidNationalID(nationalId))
                {
                    Logger.LogInfo("Invalid national ID for GetRadiologyRecordsAsync");
                    return null;
                }

                EnsureAuthorization();

                string endpoint = $"{ApiEndpoints.GetRadiology(nationalId)}";
                var result = await RequestHandler.GetAsync<RadiologyApiResponse>(endpoint);
                if (result.Message?.ToLower() != "radiology record found")
                {
                    Logger.LogError($"Failed to fetch radiology records for {nationalId}: {result?.Message ?? "Error"}");
                    return null;
                }
                else
                {
                    Logger.LogInfo($"Fetched radiology records for {nationalId}");
                    return result;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError("Error in GetRadiologyRecordsAsync", ex);
                return null;
            }
        }

        /// <summary>
        /// Updates an existing radiology record for a given patient.
        /// </summary>
        public async Task<bool> UpdateRadiologyRecordAsync(string _id, string nationalId, string radiologyType, string notes, string imagePath)
        {
            try
            {
                if (!Validator.IsValidNationalID(nationalId) || !Validator.IsNonEmpty(_id) || !Validator.IsNonEmpty(radiologyType))
                {
                    Logger.LogInfo("Invalid input for UpdateRadiologyRecordAsync");
                    return false;
                }

                EnsureAuthorization();

                var content = new MultipartFormDataContent
                {
                    { new StringContent(radiologyType), "radiology_type" },
                    { new StringContent(notes ?? ""), "radiologistNotes" }
                };

                // Include new image if provided
                if (!string.IsNullOrEmpty(imagePath) && File.Exists(imagePath))
                {
                    var imageBytes = File.ReadAllBytes(imagePath);
                    var fileContent = new ByteArrayContent(imageBytes);
                    fileContent.Headers.ContentType = new MediaTypeHeaderValue("image/jpeg");
                    content.Add(fileContent, "images", Path.GetFileName(imagePath));
                }

                string endpoint = $"{ApiEndpoints.UpdateRadiology(nationalId, _id)}";
                HttpResponseMessage response = await RequestHandler.PatchRadiologyAsync<HttpResponseMessage>(endpoint, content);
                if (!response.IsSuccessStatusCode)
                {
                    Logger.LogError($"Radiology record update failed: {response.Content}");
                    return false;
                }

                Logger.LogInfo($"Updated radiology record {_id} for {nationalId}");
                return true;
            }
            catch (Exception ex)
            {
                Logger.LogError("Error in UpdateRadiologyRecordAsync", ex);
                return false;
            }
        }

        /// <summary>
        /// Deletes a specific radiology record by _ID and national ID.
        /// </summary>
        public async Task<bool> DeleteRadiologyRecordAsync(string nationalid, string _id)
        {
            try
            {                
                if (!Validator.IsValidNationalID(nationalid) || !Validator.IsNonEmpty(_id))
                {
                    Logger.LogInfo("Invalid input for DeleteRadiologyRecordAsync");
                    return false;
                }

                EnsureAuthorization();

                string endpoint = $"{ApiEndpoints.DeleteRadiology(nationalid, _id)}";
                var response = await RequestHandler.DeleteAsync<HttpResponseMessage>(endpoint);
                if (!response.IsSuccessStatusCode)
                {
                    Logger.LogError($"Radiology record deletion failed: {response.Content}");
                    return false;
                }

                Logger.LogInfo($"Deleted radiology record {_id}");
                return true;
            }
            catch (Exception ex)
            {
                Logger.LogError("Error in DeleteRadiologyRecordAsync", ex);
                return false;
            }
        }
    }
}
