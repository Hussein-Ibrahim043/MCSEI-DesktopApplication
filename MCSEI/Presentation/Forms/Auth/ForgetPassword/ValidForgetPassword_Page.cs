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
    public partial class ValidForgetPassword_Page : Form
    {
        private FrmMain _startPage;
        private readonly IAuthService _authService;

        public string emailaddress;
        public ValidForgetPassword_Page(FrmMain startPage, string Email)
        {
            InitializeComponent();
            _startPage = startPage;
            emailaddress = Email;

            // Create service instance 
            _authService = new AuthService();
        }

        private async void VERIFYbtn_Click(object sender, EventArgs e)
        {
            string email = emailaddress;
            string code = CODEtxt.Text.Trim();

            try
            {
                // Validate fields
                if (string.IsNullOrWhiteSpace(emailaddress))
                {
                    MessageBox.Show("Email is missing or invalid.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(code))
                {
                    MessageBox.Show("Please enter the verification code.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Call signup service
                bool isValid = await _authService.ValidateForgetPasswordAsync(emailaddress, code);

                if (isValid)
                {
                    MessageBox.Show("Code confirmed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _startPage.loadform(new Pages.ResetPassword_Page(_startPage, emailaddress, code));
                }
                else
                {
                    MessageBox.Show("Invalid code. Please check your inbox and try again.", "Verification Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError("Exception in VERIFYbtn_Click", ex);
                MessageBox.Show($"Unexpected error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
