using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final_Project_SHA_V1._2.Core.Models;

namespace Final_Project_SHA_V1._2.Core.Interfaces
{
    public interface IMedicalService
    {
        //Task<MedicalRecord> GetMedicalRecordByCitizenIdAsync(string nationalId);
        Task<bool> CreateMedicalRecordAsync(CreateMedicalRequest medicalRecord);
        Task<MedicalApiResponse> GetMedicalRecordsAsync(string nationalId);
        Task<bool> UpdateMedicalRecordAsync(MedicalRequest medicalRecord, string _ID);
        Task<bool> DeleteMedicalRecordAsync(string nationalId, string _id);
    }
}
