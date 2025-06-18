using System.Threading.Tasks;
using Final_Project_SHA_V1._2.Core.Models;

namespace Final_Project_SHA_V1._2.Core.Interfaces
{
    public interface IAuthService
    {
        Task<bool> LoginAsync(string email, string password);

        Task<bool> SignupAsync(string fullName, string email, string password, string confirmationPassword);

        Task<bool> ConfirmEmailAsync(string email, string code);

        Task<bool> ForgetPasswordAsync(string email);

        Task<bool> ValidateForgetPasswordAsync(string email, string code);

        Task<bool> ResetPasswordAsync(string email, string code, string password, string confirmationPassword);

        Task<bool> UpdatePasswordAsync(string oldPassword, string password, string confirmationPassword);

        Task<bool> ChangeRoleAsync(string email, string role);

        void Logout();
    }
}