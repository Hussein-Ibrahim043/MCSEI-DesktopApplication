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
using Final_Project_SHA_V1._2.Forms;
using Final_Project_SHA_V1._2.Infrastructure.Utils;
using Final_Project_SHA_V1._2.Services;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Final_Project_SHA_V1._2.Pages
{
    public partial class UpdatePassword_Page : Form
    {
        private FrmMain _startPage;
        private readonly IAuthService _authService;

        public UpdatePassword_Page(FrmMain startPage)
        {
            InitializeComponent();
            _startPage = startPage;

            // Create service instance 
            _authService = new AuthService();
        }

        private async void UPDATEPASSWORDbtn_Click(object sender, EventArgs e)
        {
            string oldPassword = OLDPASSWORDtxt.Text;
            string password = NEWPASSWORDtxt.Text;
            string confirmationPassword = CONFIRMPASSWORDtxt.Text;
           
            

            try
            {
                // Input validation
                if (string.IsNullOrWhiteSpace(oldPassword))
                {
                    MessageBox.Show("Please enter your current password.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(confirmationPassword))
                {
                    MessageBox.Show("Please enter and confirm your new password.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (password != confirmationPassword)
                {
                    MessageBox.Show("New password and confirmation do not match.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (password == oldPassword)
                {
                    MessageBox.Show("New password must be different from the current password.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Call service
                bool updated = await _authService.UpdatePasswordAsync(oldPassword, password, confirmationPassword);

                if (updated)
                {
                    MessageBox.Show("Password updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    OLDPASSWORDtxt.Clear();
                    NEWPASSWORDtxt.Clear();
                    CONFIRMPASSWORDtxt.Clear();
                }
                else
                {
                    MessageBox.Show("Failed to update password. Please check your current password or try again later.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError("Unexpected error while updating password", ex);
                MessageBox.Show($"Unexpected error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UPDATEPASSWORD_Click(object sender, EventArgs e)
        {
            _startPage.loadform(new UpdatePassword_Page(_startPage));
            _startPage.resetButtons();
        }

        private void ADMINDASHBOARDbtn_Click(object sender, EventArgs e)
        {
            _startPage.loadform(new AdminDashboard(_startPage));
            _startPage.resetButtons();
        }

        private void Homebtn_Click(object sender, EventArgs e)
        {
            _startPage.loadform(new Dashboard_Page(_startPage));
            _startPage.resetButtons();
        }
    }
}
