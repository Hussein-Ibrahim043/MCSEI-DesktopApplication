using System.Configuration;

namespace FinalProject_MedicalSystem.Infrastructure.Http
{
    public static class ApiEndpoints
    {
        private static readonly string BaseUrl = "https://medical-website-three-delta.vercel.app";

        //Auth Endpoints
        public static string Login => $"{BaseUrl}/auth/login";
        public static string Signup => $"{BaseUrl}/auth/signup";
        public static string ConfirmEmail => $"{BaseUrl}/auth/confirm-email";
        public static string ForgetPassword => $"{BaseUrl}/auth/forget-password";
        public static string ValidForgetPassword => $"{BaseUrl}/auth/valid-forget-password";
        public static string ResetPassword => $"{BaseUrl}/auth/reset-password";
        public static string UpdatePassword => $"{BaseUrl}/auth/update-password";
        public static string ChangeRole => $"{BaseUrl}/user/dashboard/role";

        //Citizen Endpoints
        public static string FindCitizenByNationalID(string nationalId) => $"{BaseUrl}/citizens/search?national_ID={nationalId}";
        public static string CreateCitizenRecord => $"{BaseUrl}/citizens/create-citizen";
        public static string UpdateCitizenRecord(string nationalId) => $"{BaseUrl}/citizens/update-citizen/{nationalId}";
        public static string DeleteCitizenRecord(string nationalId) => $"{BaseUrl}/citizens/delete-citizen/{nationalId}";


        //Medical Endpoints
        public static string MedicalRecordById(string nationalId) => $"{BaseUrl}/medical-record/{nationalId}";
        public static string CreateMedicalRecord => $"{BaseUrl}/medical-record/create-medical-record";
        public static string UpdateMedicalRecord(string nationalId, string _id) => $"{BaseUrl}/medical-record/update-medical-record/{nationalId}/{_id}";
        public static string DeleteMedicalRecord(string nationalId, string _id) => $"{BaseUrl}/medical-record/delete-medical-record/{nationalId}/{_id}";

        //Radiology Endpoints
        public static string GetRadiology(string nationalId) => $"{BaseUrl}/radiology/{nationalId}";
        public static string CreateRadiology => $"{BaseUrl}/radiology/create-radiology";
        public static string UpdateRadiology(string nationalId, string _id) => $"{BaseUrl}/radiology/update-radiology/{nationalId}/{_id}";
        public static string DeleteRadiology(string nationalid, string _id) => $"{BaseUrl}/radiology/delete-radiology/{nationalid}/{_id}";


        //Dashboard
        public static string Export(string nationalId) => $"{BaseUrl}/user/dashboard?national_ID={nationalId}";
    }
}
