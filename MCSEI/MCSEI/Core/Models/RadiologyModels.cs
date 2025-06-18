using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Final_Project_SHA_V1._2.Core.Models
{
    public class RadiologyApiResponse
    {
        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("data")]
        public RadiologyData Data { get; set; } // ✅ Now matches the actual structure
    }

    public class RadiologyData
    {
        [JsonProperty("radiology")]
        public List<RadiologyRecord> Radiology { get; set; }

        [JsonProperty("citizen")]
        public List<CitizenInformation> Citizen { get; set; }
    }

    public class CitizenInformation
    {
        [JsonProperty("national_ID")]
        public string NationalID { get; set; }

        [JsonProperty("full_name")]
        public string FullName { get; set; }
    }

    public class RadiologyRecord
    {
        [JsonProperty("_id")]
        public string _id { get; set; }
        
        [JsonProperty("national_ID")] 
        public string NationalID { get; set; }

        [JsonProperty("radiology_type")]
        public string RadiologyType { get; set; }

        [JsonProperty("radiologistNotes")]
        public string Report { get; set; }

        [JsonProperty("radiology_date")]
        public DateTime Date { get; set; }

        [JsonProperty("images")]
        public List<ImageData> Images { get; set; }  //hold the images data
    }

    public class RadiologyRequest
    {        
        [JsonProperty("national_ID")]
        public string NationalID { get; set; }

        [JsonProperty("radiology_type")]
        public string RadiologyType { get; set; }

        [JsonProperty("radiologistNotes")]
        public string Report { get; set; }

        [JsonProperty("images")]
        public List<ImageData> Images { get; set; }  //hold the images data
    }
    public class ImageData
    {
        [JsonProperty("secure_url")]
        public string SecureUrl { get; set; }
    }

}
