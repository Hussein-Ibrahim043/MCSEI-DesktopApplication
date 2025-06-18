using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final_Project_SHA_V1._2.Core.Models;

namespace Final_Project_SHA_V1._2.Core.Interfaces
{
    public interface IRadiologyService
    {
        Task<bool> CreateRadiologyRecordAsync(string nationalId, string radiologyType, string Report, string imagePath);
        Task<RadiologyApiResponse> GetRadiologyRecordsAsync(string nationalId);
        Task<bool> UpdateRadiologyRecordAsync(string _id, string nationalId, string radiologyType, string notes, string imagePath);
        Task<bool> DeleteRadiologyRecordAsync(string nationalid, string _id);
    }
}
