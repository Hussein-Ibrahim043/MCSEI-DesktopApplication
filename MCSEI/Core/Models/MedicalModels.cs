using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Final_Project_SHA_V1._2.Core.Models
{
    public class MedicalApiResponse
    {
        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("data")]
        public MedicalData Data { get; set; }
    }

    public class MedicalData
    {
        [JsonProperty("medicalRecord")]
        public List<MedicalRecord> MedicalRecords { get; set; }

        [JsonProperty("citizen")]
        public List<CitizenInfo> Citizen { get; set; }
    }
    public class MedicalRecord
    {
        [JsonProperty("_id")] public string _id { get; set; }
        [JsonProperty("national_ID")] public string NationalID { get; set; }
        [JsonProperty("treatment")] public string Treatment { get; set; }
        [JsonProperty("diagnosis")] public string Diagnosis { get; set; }
        [JsonProperty("clinic_name")] public string ClinicName { get; set; }
        [JsonProperty("clinic_code")] public int ClinicCode { get; set; }
        [JsonProperty("status")] public bool Status { get; set; }
        [JsonProperty("recode_date")] public DateTime RecodeDate { get; set; }
        [JsonProperty("modified_on")] public DateTime ModifiedOn { get; set; }
    }

    public class MedicalRequest
    {
        [JsonProperty("national_ID")] public string NationalID { get; set; }
        [JsonProperty("treatment")] public string Treatment { get; set; }
        [JsonProperty("diagnosis")] public string Diagnosis { get; set; }
        [JsonProperty("clinic_name")] public string ClinicName { get; set; }
        [JsonProperty("clinic_code")] public int ClinicCode { get; set; }
        [JsonProperty("status")] public bool Status { get; set; }        
    }

    public class CreateMedicalRequest
    {
        [JsonProperty("national_ID")] public string NationalID { get; set; }
        [JsonProperty("treatment")] public string Treatment { get; set; }
        [JsonProperty("diagnosis")] public string Diagnosis { get; set; }
        [JsonProperty("clinic_name")] public string ClinicName { get; set; }
        [JsonProperty("clinic_code")] public int ClinicCode { get; set; }        
    }
}
