using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final_Project_SHA_V1._2.Core.Models;

namespace Final_Project_SHA_V1._2.Core.Interfaces
{
    public interface IExportService
    {
        Task<string> ExportDataAsJsonAsync(string nationalId);
        Task<bool> ExportDataToJsonFileAsync(string nationalId, string filePath);
        //(string Diagnosis, string Treatment, string RadiologyImageUrl) ExtractMedicalData(ExportApiResponse apiData);
    }
}
