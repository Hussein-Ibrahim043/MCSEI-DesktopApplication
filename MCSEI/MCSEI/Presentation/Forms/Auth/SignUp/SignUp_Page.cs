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

namespace Final_Project_SHA_V1._2.Pages
{
    public partial class SignUp_Page : Form
    {
        private FrmMain _startPage;
        private readonly IAuthService _authService;


        public SignUp_Page(FrmMain startPage)
        {
            InitializeComponent();
            _startPage = startPage;

            // Create service instance
            _authService = new AuthService();
        }

        private void LOGINPAGEbtn_Click(object sender, EventArgs e)
        {
            _startPage.loadform(new Pages.Login_Page(_startPage));
        }

        private async void SIGNUPbtn_Click(object sender, EventArgs e)
        {
            try
            {
                // Get and trim input
                string userName = FULLNAMEtb.Text.Trim();
                string email = EMAILADDRESStb.Text.Trim();
                string password = PASSWORDtb.Text.Trim();
                string confirmationPassword = CONFIRMPASSWORDtb.Text.Trim();

                // Validate fields
                if (string.IsNullOrWhiteSpace(userName) || string.IsNullOrWhiteSpace(email) ||
                    string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(confirmationPassword))
                {
                    MessageBox.Show("Please fill in all required fields.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (password != confirmationPassword)
                {
                    MessageBox.Show("Passwords do not match.", "Password Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Call signup service
                bool isSignedUp = await _authService.SignupAsync(userName, email, password, confirmationPassword);

                if (isSignedUp)
                {
                    MessageBox.Show("Signup successful! Please verify your email.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    var confirmPage = new Pages.Confirm_Email(_startPage);
                    _startPage.loadform(confirmPage);
                }
                else
                {
                    MessageBox.Show("Signup failed. Please check your information and try again.",
                                    "Signup Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError("Unhandled exception in SIGNUPbtn_Click", ex);

                MessageBox.Show($"An unexpected error occurred:\n{ex.Message}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
    }
}
