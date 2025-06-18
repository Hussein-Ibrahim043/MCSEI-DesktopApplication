using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Final_Project_SHA_V1._2.Core.Models
{
    /// <summary>
    /// Response received when fetching a citizen's record.
    /// </summary>
    public class CitizenRecordResponse
    {
        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("citizen")]
        public CitizenData Citizen { get; set; }
    }

    /// <summary>
    /// request payload to create or update.
    /// </summary>
    public class CitizenRequest
    {
        [JsonProperty("national_ID")]
        public string NID { get; set; }

        [JsonProperty("full_name")]
        public string FullName { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("blood_type")]
        public string BloodType { get; set; }

        [JsonProperty("birth_date")]
        public string BirthDate { get; set; }

        [JsonProperty("mobileNumber")]
        public string MobileNumber { get; set; }
    }

    /// <summary>
    /// citizen data.
    /// </summary>
    public class CitizenData
    {
        [JsonProperty("_id")]
        public string _id { get; set; }

        [JsonProperty("national_ID")]
        public string NID { get; set; }

        [JsonProperty("full_name")]
        public string FullName { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("blood_type")]
        public string BloodType { get; set; } 

        [JsonProperty("birth_date")]
        public DateTime BirthDate { get; set; }

        [JsonProperty("mobileNumber")]
        public string MobileNumber { get; set; }

        [JsonProperty("gender")]
        public string Gender { get; set; }

        [JsonProperty("createdAt")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("updatedAt")]
        public DateTime UpdatedAt { get; set; }
    }

    /// <summary>
    /// citizen data for use in dropdowns, search results, etc.
    /// </summary>
    public class CitizenInfo
    {
        [JsonProperty("national_ID")]
        public string NationalID { get; set; }

        [JsonProperty("full_name")]
        public string FullName { get; set; } 
    }
}