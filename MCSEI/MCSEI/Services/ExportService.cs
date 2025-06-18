using Final_Project_SHA_V1._2.Core.Interfaces;
using Final_Project_SHA_V1._2.Core.Models;
using Final_Project_SHA_V1._2.Infrastructure.Utils;
using Final_Project_SHA_V1._2.Services;
using FinalProject_MedicalSystem.Infrastructure.Http;
using Infrastructure.Http;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.IO;

public class ExportService : IExportService
{    
    private static readonly CitizenService _citizenService = new CitizenService();

    /// <summary>
    /// Export all relevant data (citizen, medical, and radiology) as a JSON string is specific format.
    /// </summary>
    public async Task<string> ExportDataAsJsonAsync(string nationalId)
    {
        try
        {
            // Validate National ID format
            if (!Validator.IsValidNationalID(nationalId))
                throw new ArgumentException("Invalid National ID");

            // Fetch citizen information
            CitizenRecordResponse citizenResponse = await _citizenService.GetCitizenByNationalIdAsync(nationalId);
            var citizen = citizenResponse.Citizen;

            // Ensure citizen data exists
            if (citizen == null)
                throw new Exception("Citizen data not found");

            // Fetch diagnosis, treatment, and radiology image
            ExportApiResponse apiData = await RequestExportDataAsync(nationalId);
            var (diagnosis, treatment, imageUrl) = ExtractMedicalData(apiData);

            // Compose export object
            var exportData = new
            {
                NationalId = nationalId,
                FullName = citizen.FullName,
                BirthDate = citizen.BirthDate.ToString("yyyy-MM-dd"),
                Address = citizen.Address,
                BloodType = citizen.BloodType,
                ContactNo = citizen.MobileNumber,
                Diagnosis = diagnosis,
                Treatment = treatment,
                ImageUrl = imageUrl,
                Extracted_Date = DateTime.Today.ToString("yyyy-MM-dd")
            };

            // Convert to formatted JSON string
            return JsonConvert.SerializeObject(exportData, Formatting.Indented);
        }
        catch (Exception ex)
        {
            Logger.LogError("Export failed", ex);
            return $"{{ \"error\": \"{ex.Message}\" }}"; // Return error as JSON format
        }
    }

    /// <summary>
    ///Fetch exportable medical and radiology data.
    /// </summary>
    private async Task<ExportApiResponse> RequestExportDataAsync(string nationalId)
    {
        string endpoint = $"{ApiEndpoints.Export(nationalId)}";
        return await RequestHandler.GetAsync<ExportApiResponse>(endpoint);
    }

    /// <summary>
    /// Extracts diagnosis, treatment, and radiology image URL from the API response.
    /// </summary>
    private (string Diagnosis, string Treatment, string RadiologyImageUrl) ExtractMedicalData(ExportApiResponse apiData)
    {
        var result = apiData.data.result;

        var diagnosisList = new List<string>();
        var treatmentList = new List<string>();
        string secureUrl = "N/A";

        // Parse diagnosis and treatment from fulfilled result[1]
        if (result.Count >= 2 && result[1].status == "fulfilled")
        {
            foreach (var rec in result[1].value)
            {
                var med = rec.ToObject<MedicalRecordExport>();
                if (!string.IsNullOrWhiteSpace(med.diagnosis)) diagnosisList.Add(med.diagnosis);
                if (!string.IsNullOrWhiteSpace(med.treatment)) treatmentList.Add(med.treatment);
            }
        }

        // Parse radiology image from fulfilled result[2]
        if (result.Count >= 3 && result[2].status == "fulfilled")
        {
            foreach (var rec in result[2].value)
            {
                var radio = rec.ToObject<Radiology>();
                if (radio.images != null && radio.images.Count > 0)
                {
                    secureUrl = radio.images[0].secure_url ?? "N/A";
                    break;
                }
            }
        }

        // Return the data as a tuple
        return (
            diagnosisList.Count > 0 ? string.Join(", ", diagnosisList) : "N/A",
            treatmentList.Count > 0 ? string.Join(", ", treatmentList) : "N/A",
            secureUrl
        );
    }

    /// <summary>
    /// Saves exported JSON data to a file.
    /// </summary>
    public async Task<bool> ExportDataToJsonFileAsync(string nationalId, string filePath)
    {
        try
        {
            string jsonData = await ExportDataAsJsonAsync(nationalId);

            // Optional: if you want to reject writing errors to file
            // if (jsonData.Contains("\"error\"")) return false;

            File.WriteAllText(filePath, jsonData);
            Logger.LogInfo($"Exported JSON data for National ID {nationalId} to file: {filePath}");
            return true;
        }
        catch (Exception ex)
        {
            Logger.LogError("File export failed", ex);
            return false;
        }
    }
}