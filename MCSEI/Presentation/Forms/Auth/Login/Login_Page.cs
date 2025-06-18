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
using Final_Project_SHA_V1._2.Services;
using Newtonsoft.Json.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Final_Project_SHA_V1._2.Pages
{
    public partial class Login_Page : Form
    {
        
        private FrmMain _startPage;
        private readonly IAuthService _authService;

        public Login_Page(FrmMain startPage)
        {
            InitializeComponent();
            _startPage = startPage;

            // Create service instance
            _authService = new AuthService();
        }

        private void SIGNUPPAGEbtn_Click(object sender, EventArgs e)
        {
            _startPage.loadform(new Pages.SignUp_Page(_startPage));
        }

        private async void LOGINbtn_Click(object sender, EventArgs e)
        {
            try
            {
                string email = EMAILADDRESStb.Text.Trim();
                string password = PASSWORDtb.Text.Trim();
              

                bool response = await _authService.LoginAsync(email, password);

                if (response)
                {                                        
                    Dashboard_Page dashboard = new Pages.Dashboard_Page(_startPage);
                    _startPage.loadform(dashboard);
                    _startPage.activateButtons();
                }
                else
                {
                    MessageBox.Show("Login failed. Please check your credentials.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to Login: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void label3_Click(object sender, EventArgs e)
        {
            _startPage.loadform(new Pages.ForgetPassword_Page(_startPage));
        }
    }

}
