using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final_Project_SHA_V1._2.Pages;
using Newtonsoft.Json.Linq;

namespace Final_Project_SHA_V1._2.Core.Models
{
    public class ExportApiResponse
    {
        public string message { get; set; }
        public Data data { get; set; }
    }

    public class Data
    {
        public List<ResultWrapper> result { get; set; }
    }

    public class ResultWrapper
    {
        public string status { get; set; }
        public List<JToken> value { get; set; }
    }

    // Models
    public class CitizenExport
    {
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Address { get; set; }
        public string BloodType { get; set; }
        public string MobileNumber { get; set; }
    }

    public class MedicalRecordExport
    {
        public string diagnosis { get; set; }
        public string treatment { get; set; }
    }

    public class RadiologyImage
    {
        public string secure_url { get; set; }
    }

    public class Radiology
    {
        public List<RadiologyImage> images { get; set; }
    }
}
