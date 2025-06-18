using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Final_Project_SHA_V1._2.Core.Interfaces;
using Final_Project_SHA_V1._2.Core.Models;
using Final_Project_SHA_V1._2.Forms;
using Final_Project_SHA_V1._2.Infrastructure.Utils;
using Final_Project_SHA_V1._2.Services;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Final_Project_SHA_V1._2.Pages
{ 
    public partial class ResetPassword_Page : Form
    {
        private FrmMain _startPage;
        public string emailaddress;
        public string code;

        private readonly IAuthService _authService;
        public ResetPassword_Page(FrmMain startPage,string Email, string Code)
        {
            InitializeComponent();
            _startPage = startPage;
            emailaddress = Email;
            code = Code;


            // Create service instance
            _authService = new AuthService();
        }

        private async void RESETbtn_Click(object sender, EventArgs e)
        {

            string email = emailaddress;
            string Code = code;
            string password = PASSWORDtxt.Text.Trim();
            string confirmationPassword = CONFIRMPASSWORDtxt.Text.Trim();     

            try
            {
                // Validate required fields
                if (string.IsNullOrWhiteSpace(emailaddress))
                {
                    MessageBox.Show("Email is missing or invalid.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(code))
                {
                    MessageBox.Show("Reset code is missing.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(confirmationPassword))
                {
                    MessageBox.Show("Please enter both password and confirmation.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (password != confirmationPassword)
                {
                    MessageBox.Show("Passwords do not match.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Call the reset service
                bool isReset = await _authService.ResetPasswordAsync(emailaddress, code, password, confirmationPassword);

                if (isReset)
                {
                    MessageBox.Show("Password reset successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _startPage.loadform(new Pages.Login_Page(_startPage));
                }
                else
                {
                    MessageBox.Show("Failed to reset password. Please check your information and try again.", "Reset Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception ex)
            {
                Logger.LogError("Error during password reset", ex);
                MessageBox.Show($"Unexpected error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
