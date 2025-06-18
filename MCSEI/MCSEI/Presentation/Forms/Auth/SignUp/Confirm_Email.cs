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
    public partial class Confirm_Email : Form
    {
        private FrmMain _startPage;
        private readonly IAuthService _authService;


        public Confirm_Email(FrmMain startPage)
        {
            InitializeComponent();
            _startPage = startPage;

            // Create service instance 
            _authService = new AuthService();
        }

        private async void CONFIRMbtn_Click(object sender, EventArgs e)
        {

            
            string email = EMAILADDRESStb.Text.Trim();
            string code = CONFIRMCODEtb.Text.Trim();
            

            try
            {
                // Input validation
                if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(code))
                {
                    MessageBox.Show("Please enter both your email and confirmation code.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!Validator.IsValidEmail(email))
                {
                    MessageBox.Show("Please enter a valid email address.", "Invalid Email", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Call the confirmation service
                bool isConfirmed = await _authService.ConfirmEmailAsync(email, code);

                if (isConfirmed)
                {
                    MessageBox.Show("Email confirmed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    var loginPage = new Login_Page(_startPage);
                    _startPage.loadform(loginPage);
                }
                else
                {
                    MessageBox.Show("Verification failed. Please check your code and try again.", "Verification Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError("Unhandled exception during email confirmation", ex);
                MessageBox.Show($"An unexpected error occurred:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
