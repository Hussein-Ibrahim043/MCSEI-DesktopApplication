using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final_Project_SHA_V1._2.Core.Models;

namespace Final_Project_SHA_V1._2.Core.Interfaces

{
    public interface ICitizenService
    {
        /// <summary>
        /// Creates a new citizen record.
        /// </summary>
        Task<bool> CreateCitizenRecordAsync(string NID, string FullName, string Address, string BloodType, string BirthDate, string Phone);

        /// <summary>
        /// Fetches a citizen's data by national ID.
        /// </summary>
        Task<CitizenRecordResponse> GetCitizenByNationalIdAsync(string nationalId);

        /// <summary>
        /// Updates an existing citizen record.
        /// </summary>
        Task<bool> UpdateCitizenAsync(string NID, string FullName, string Address, string BloodType, string BirthDate, string Phone);

        /// <summary>
        /// Deletes a citizen record by national ID.
        /// </summary>
        Task<bool> DeleteCitizenAsync(string nationalId);
    }
}
