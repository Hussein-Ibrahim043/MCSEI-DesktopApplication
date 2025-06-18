using System;
using System.Windows.Forms;
using Final_Project_SHA_V1._2.Core.Interfaces;
using Final_Project_SHA_V1._2.Forms;
using Final_Project_SHA_V1._2.Infrastructure.Utils;
using Final_Project_SHA_V1._2.Services;

namespace Final_Project_SHA_V1._2.Pages
{
    public partial class AdminDashboard : Form
    {
        private FrmMain _startPage;
        private readonly IAuthService _authService;


        public AdminDashboard(FrmMain startPage)
        {
            InitializeComponent();
            _startPage = startPage;

            // Create service instance 
            _authService = new AuthService();
        }

        private void UPDATEPASSWORDbtn_Click(object sender, EventArgs e)
        {
            _startPage.loadform(new UpdatePassword_Page(_startPage));
            _startPage.resetButtons();
        }

        private void ADMINDASHBOARDbtn_Click(object sender, EventArgs e)
        {
            _startPage.loadform(new AdminDashboard(_startPage));
            _startPage.resetButtons();
        }

        private async void CHANGEROLEbtn_Click(object sender, EventArgs e)
        {
            string Email = EMAILADDRESStb.Text;
            string Role = ROLElb.Text;
            
            try
            {
                // Validate input fields
                if (string.IsNullOrWhiteSpace(Email) || !Validator.IsValidEmail(Email))
                {
                    MessageBox.Show("Please enter a valid email address.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(Role) || !Validator.IsValidRole(Role))
                {
                    MessageBox.Show("Please select a valid role.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Call the service
                bool isChanged = await _authService.ChangeRoleAsync(Email, Role);

                if (isChanged)
                {
                    MessageBox.Show("Role changed successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Failed to change role. You may not have permission or data is incorrect.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Not Authorized", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Homebtn_Click(object sender, EventArgs e)
        {
            _startPage.loadform(new Dashboard_Page(_startPage));
            _startPage.resetButtons();
        }
    }
}
