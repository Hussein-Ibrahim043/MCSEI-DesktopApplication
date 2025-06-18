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
    public partial class ForgetPassword_Page : Form
    {
        private FrmMain _startPage;
        private readonly IAuthService _authService;

        public ForgetPassword_Page(FrmMain startPage)
        {
            InitializeComponent();
            _startPage = startPage;

            // Create service instance 
            _authService = new AuthService();
        }

        private async void SENDCODEbtn_Click(object sender, EventArgs e)
        {
            string email = EMAILADDRESStb.Text.Trim();

            try
            {
                // Validate input
                if (string.IsNullOrWhiteSpace(email))
                {
                    MessageBox.Show("Please enter your email address.", "Missing Email", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!Validator.IsValidEmail(email))
                {
                    MessageBox.Show("Please enter a valid email address.", "Invalid Email", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Call the forget password service
                bool isSent = await _authService.ForgetPasswordAsync(email);

                if (isSent)
                {
                    MessageBox.Show("Verification code sent successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _startPage.loadform(new Pages.ValidForgetPassword_Page(_startPage, email));
                }
                else
                {
                    MessageBox.Show("Failed to send verification code. Please try again.", "Send Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError("Exception while sending forget password code.", ex);
                MessageBox.Show($"An unexpected error occurred:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SIGNINbtn_Click(object sender, EventArgs e)
        {
            _startPage.loadform(new Pages.Login_Page(_startPage));
        }

        private void SIGNUPPAGEbtn_Click(object sender, EventArgs e)
        {
            _startPage.loadform(new Pages.SignUp_Page(_startPage));
        }
    }
}
